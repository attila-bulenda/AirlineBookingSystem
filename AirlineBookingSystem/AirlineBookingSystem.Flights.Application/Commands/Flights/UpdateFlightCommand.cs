using AirlineBookingSystem.Flights.Application.Exceptions;
using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Flights
{
    public record UpdateFlightCommand(int id, FlightDto flight) : IRequest<DatabaseOperationResult>;
}
