using AirlineBookingSystem.Flights.Infrastructure.Context;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Core.Models;

namespace AirlineBookingSystem.Flights.Infrastructure.Repositories
{
    public class FlightsRepository: GenericRepository<Flight>, IFlightsRepository
    {
        public FlightsRepository(FlightsDbContext context): base(context)
        {
            
        }
    }
}
