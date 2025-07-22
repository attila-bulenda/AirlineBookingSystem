using AirlineBookingSystem.Flights.Core.Models;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands.Bookings
{
    public record CreateBookingCommand(Booking booking) : IRequest;
}
