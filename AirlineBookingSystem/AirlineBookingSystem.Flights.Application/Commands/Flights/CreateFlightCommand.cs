using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Models;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Flights
{
    public record CreateFlightCommand(FlightDto flight): IRequest<int>;
}
