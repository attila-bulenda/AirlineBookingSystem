using AirlineBookingSystem.Flights.Core.Models;

namespace AirlineBookingSystem.Flights.Core.Interfaces
{
    public interface IFlightsRepository: IGenericRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetAllWithBookingsAsync();
    }
}
