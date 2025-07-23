using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Queries.Bookings
{
    public record GetAllBookingsQuery: IRequest<IEnumerable<BookingDetailsDto>>;
}
