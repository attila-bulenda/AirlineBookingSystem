using AirlineBookingSystem.Invoices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
