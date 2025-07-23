using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Flights
{
    public record CreateFlightCommand(FlightDto flight): IRequest<int>;
}
