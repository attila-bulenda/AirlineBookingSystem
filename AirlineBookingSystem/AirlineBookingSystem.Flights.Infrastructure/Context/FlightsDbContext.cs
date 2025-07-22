using AirlineBookingSystem.Flights.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AirlineBookingSystem.Flights.Infrastructure.Context
{
    public class FlightsDbContext: DbContext
    {
        public FlightsDbContext(DbContextOptions<FlightsDbContext> options) : base(options){}

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
