using AirlineBookingSystem.Users.Application.Configurations;
using AirlineBookingSystem.Users.Core.Interfaces;
using AirlineBookingSystem.Users.Core.Models;
using AirlineBookingSystem.Users.Infrastructure.Context;
using AirlineBookingSystem.Users.Infrastructure.Configurations;
using AirlineBookingSystem.Users.Infrastructure.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Adding the SQLite DB connection
var userDbName = builder.Configuration.GetConnectionString("SqlDbConnectionString");
var userDbPath = $"DataSource=./Database/{userDbName}";
builder.Services.AddDbContext<SystemUserDbContext>(options =>
{
    options.UseSqlite(userDbPath)
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
           .LogTo(Console.WriteLine, LogLevel.Information);

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

// Registering Identity services
builder.Services.AddIdentityCore<SystemUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<SystemUser>>("AirlineBookingSystem")
    .AddEntityFrameworkStores<SystemUserDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDataProtection();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });

// Adding dependency injection
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

// Adding MediatR handlers
var handlers = HandlerAssemblies.GetMediatRHandlers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

// Adding AutoMapper
var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperConfiguration>();
}, loggerFactory);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

// User seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<SystemUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await UserSeedingConfiguration.SeedAsync(userManager, roleManager);
}

app.Run();
