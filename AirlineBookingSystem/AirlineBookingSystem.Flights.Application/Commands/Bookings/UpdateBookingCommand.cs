using AirlineBookingSystem.Flights.Application.Exceptions;
using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Bookings
{
    public record UpdateBookingCommand(int id, BookingCreateDto booking): IRequest<DatabaseOperationResult>;
}
