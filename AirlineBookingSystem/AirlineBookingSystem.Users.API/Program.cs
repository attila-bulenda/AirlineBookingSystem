using AirlineBookingSystem.Users.Application.Configurations;
using AirlineBookingSystem.Users.Core.Interfaces;
using AirlineBookingSystem.Users.Core.Models;
using AirlineBookingSystem.Users.Infrastructure.Context;
using AirlineBookingSystem.Users.Infrastructure.Services;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
    //.AddTokenProvider<DataProtectorTokenProvider<SystemUser>>("HotelListingApi")
    .AddEntityFrameworkStores<SystemUserDbContext>();
    //.AddDefaultTokenProviders();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
