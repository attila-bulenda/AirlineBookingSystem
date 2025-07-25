using AirlineBookingSystem.Notifications.Application.Consumers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EventBus;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add MassTransit
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<UserCreatedEventConsumer>();
    config.AddConsumer<UserDeletedEventConsumer>();
    config.AddConsumer<FlightUpdatedConsumer>();
    config.AddConsumer<InvoiceCreatedConsumer>();

    config.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.UserCreatedQueue, c =>
        {
            c.ConfigureConsumer<UserCreatedEventConsumer>(ct);
        });
        cfg.ReceiveEndpoint(EventBusConstants.UserDeletedQueue, c =>
        {
            c.ConfigureConsumer<UserDeletedEventConsumer>(ct);
        });
        cfg.ReceiveEndpoint(EventBusConstants.FlightUpdatedQueue, c =>
        {
            c.ConfigureConsumer<FlightUpdatedConsumer>(ct);
        });
        cfg.ReceiveEndpoint(EventBusConstants.InvoiceCreatedQueue, c =>
        {
            c.ConfigureConsumer<InvoiceCreatedConsumer>(ct);
        });
    });
});

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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
