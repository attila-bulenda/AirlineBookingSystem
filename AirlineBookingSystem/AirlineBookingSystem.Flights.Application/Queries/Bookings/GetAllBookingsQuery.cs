using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Models;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Queries.Bookings
{
    public record GetAllBookingsQuery: IRequest<IEnumerable<BookingDetailsDto>>;
}
