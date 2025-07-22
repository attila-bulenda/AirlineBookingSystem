using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Queries.Flights
{
    public record GetFlightQuery(int id): IRequest<FlightDto>;
}
