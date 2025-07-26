using AirlineBookingSystem.Global.ErrorHandlingService.Configurations;
using AirlineBookingSystem.Global.ErrorHandlingService.Interfaces;
using AirlineBookingSystem.Invoices.Application.Configurations;
using AirlineBookingSystem.Invoices.Application.Consumers;
using AirlineBookingSystem.Invoices.Core.Interfaces;
using AirlineBookingSystem.Invoices.Infrastructure.Context;
using AirlineBookingSystem.Invoices.Infrastructure.Repositories;
using AutoMapper;
using EventBus;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HandlerAssemblies = AirlineBookingSystem.Invoices.Application.Configurations.HandlerAssemblies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Adding the SQLite database and the DB context
var dbName = builder.Configuration.GetConnectionString("SqlDbConnectionString");
var connectionString = $"DataSource = ./Database/{dbName}";
builder.Services.AddDbContext<InvoicesDbContext>(options =>
{
    options.UseSqlite(connectionString)
          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
          .LogTo(Console.WriteLine, LogLevel.Information);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

// Adding AutoMapper
var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperConfiguration>();
}, loggerFactory);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add MassTransit
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BookingCreatedConsumer>();

    config.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.BookingCreatedQueue, c =>
        {
            c.ConfigureConsumer<BookingCreatedConsumer>(ct);
        });
    });
});

// Adding MediatR handlers
var handlers = HandlerAssemblies.GetMediatRHandlers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

// Adding dependency injections
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IInvoicesRepository, InvoicesRepository>();
builder.Services.AddSingleton<IErrorStreamHandlingServiceConfiguration, ErrorStreamHandlingServiceConfiguration>();
builder.Services.Configure<EventBusSettings>(
    builder.Configuration.GetSection("EventBusSettings"));

// Adding authentication strategy
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
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler("/error/uncaught-exception");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
