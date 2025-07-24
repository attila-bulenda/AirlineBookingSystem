using AirlineBookingSystem.Notifications.Application.Consumers;
using EventBus;
using MassTransit;

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
    });
});


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
