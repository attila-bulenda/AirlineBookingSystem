using AirlineBookingSystem.Flights.Core.Models;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Flights
{
    public record UpdateFlightCommand(int id, Flight flight) : IRequest;
}
