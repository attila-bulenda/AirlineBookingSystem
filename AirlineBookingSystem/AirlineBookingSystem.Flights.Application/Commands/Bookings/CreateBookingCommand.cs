using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Bookings
{
    public record CreateBookingCommand(BookingCreateDto booking) : IRequest<int>;
}
