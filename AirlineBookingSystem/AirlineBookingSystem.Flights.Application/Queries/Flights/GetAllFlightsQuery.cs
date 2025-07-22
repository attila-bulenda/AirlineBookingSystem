using AirlineBookingSystem.Flights.Core.Models;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Queries.Flights
{
    public record GetAllFlightsQuery: IRequest<IEnumerable<Flight>>;
}
