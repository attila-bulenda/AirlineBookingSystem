using AirlineBookingSystem.Flights.Application.Exceptions;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Flights
{
    public record DeleteFlightCommand(int id): IRequest<DatabaseOperationResult>;
}
