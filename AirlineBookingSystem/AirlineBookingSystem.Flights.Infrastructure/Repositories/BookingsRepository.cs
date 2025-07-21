using AirlineBookingSystem.Flights.API.Context;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Core.Models;

namespace AirlineBookingSystem.Flights.Infrastructure.Repositories
{
    public class BookingsRepository: GenericRepository<Booking>, IBookingsRepository
    {
        public BookingsRepository(FlightsDbContext context): base(context)
        {
                
        }
    }
}
