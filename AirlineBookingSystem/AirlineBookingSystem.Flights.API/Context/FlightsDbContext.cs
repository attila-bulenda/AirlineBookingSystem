using AirlineBookingSystem.Flights.API.Database.Configurations;
using AirlineBookingSystem.Flights.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.API.Context
{
    public class FlightsDbContext: DbContext
    {
        public FlightsDbContext(DbContextOptions<FlightsDbContext> options) : base(options){}

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FlightConfigurations());
        }
    }
}
