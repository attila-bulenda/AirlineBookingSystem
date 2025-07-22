using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Queries.Flights
{
    public record GetAllFlightsQuery: IRequest<IEnumerable<FlightDetailsDto>>;
}
