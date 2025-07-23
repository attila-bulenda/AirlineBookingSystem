using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Core.Models;
using AirlineBookingSystem.Flights.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.Infrastructure.Repositories
{
    public class FlightsRepository: GenericRepository<Flight>, IFlightsRepository
    {
        FlightsDbContext _context;
        public FlightsRepository(FlightsDbContext context): base(context)
        {
            _context = context;
            
        }
        public async Task<IEnumerable<Flight>> GetAllWithBookingsAsync()
        {
            return await _context.Flights
                .Include(flight => flight.Bookings)
                .ToListAsync();
        }
    }
}
