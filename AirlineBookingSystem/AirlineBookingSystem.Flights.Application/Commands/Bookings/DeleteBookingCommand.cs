using AirlineBookingSystem.Flights.Application.Exceptions;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Bookings
{
    public record DeleteBookingCommand(int id): IRequest<DatabaseOperationResult>;
}
