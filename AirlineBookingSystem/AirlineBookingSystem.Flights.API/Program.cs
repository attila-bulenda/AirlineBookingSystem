using AirlineBookingSystem.Flights.Application.Configurations;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Infrastructure.Context;
using AirlineBookingSystem.Flights.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Adding the SQLite database and the DB context
var dbName = builder.Configuration.GetConnectionString("SqlDbConnectionString");
var connectionString = $"DataSource = ./Database/{dbName}";
builder.Services.AddDbContext<FlightsDbContext>(options =>
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

// Adding dependency injections
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IFlightsRepository, FlightsRepository>();
builder.Services.AddScoped<IBookingsRepository, BookingsRepository>();

// Adding MediatR handlers
var handlers = HandlerAssemblies.GetMediatRHandlers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

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
