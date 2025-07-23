using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Queries.Flights
{
   public record GetAllFlightsWithBookingsQuery : IRequest<IEnumerable<FlightDetailsDto>>;
}
