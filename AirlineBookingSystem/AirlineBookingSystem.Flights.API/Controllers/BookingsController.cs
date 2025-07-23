using AirlineBookingSystem.Flights.Application.Commands.Bookings;
using AirlineBookingSystem.Flights.Application.Commands.Flights;
using AirlineBookingSystem.Flights.Application.Queries.Bookings;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Models;
using AirlineBookingSystem.Flights.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator? _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery());
            return bookings is null ? NotFound() : Ok(bookings);
        }

        // GET: api/bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _mediator.Send(new GetBookingQuery(id));
            return booking is null ? NotFound() : Ok(booking);
        }

        // PUT: api/bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, BookingCreateDto booking)
        {
            var result = await _mediator.Send(new UpdateBookingCommand(id, booking));
            if (result.NotFound)
            {
                return NotFound();
            }
            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(BookingCreateDto booking)
        {
           var bookingId = await _mediator.Send(new CreateBookingCommand(booking));
           return CreatedAtAction("GetBooking", new { id = bookingId }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _mediator.Send(new DeleteBookingCommand(id));
            if (result.NotFound)
            {
                return NotFound();
            }
            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return NoContent();
        }
    }
}
