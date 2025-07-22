using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Core.Models;
using AirlineBookingSystem.Flights.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.Infrastructure.Repositories
{
    public class BookingsRepository: GenericRepository<Booking>, IBookingsRepository
    {
        FlightsDbContext _context;
        public BookingsRepository(FlightsDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Booking> GetAsync(int? id)
        {
            return await _context.Bookings
                .Include(x => x.Flight)
                .FirstOrDefaultAsync(booking => booking.Id == id);                
        }
        public override async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(booking => booking.Flight)
                .ToListAsync();
        }
    }
}
