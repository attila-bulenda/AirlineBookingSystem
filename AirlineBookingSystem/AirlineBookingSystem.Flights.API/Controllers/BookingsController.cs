using AirlineBookingSystem.Flights.Application.Commands.Bookings;
using AirlineBookingSystem.Flights.Application.Queries.Bookings;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Flights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator? _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/bookings
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(IEnumerable<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery());
            return bookings is null ? NotFound() : Ok(bookings);
        }

        // GET: api/bookings/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _mediator.Send(new GetBookingQuery(id));
            return booking is null ? NotFound() : Ok(booking);
        }

        // PUT: api/bookings/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        // POST: api/bookings
        [HttpPost]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Booking>> CreateBooking(BookingCreateDto booking)
        {
           var bookingId = await _mediator.Send(new CreateBookingCommand(booking));
           return CreatedAtAction("GetBooking", new { id = bookingId }, booking);
        }

        // DELETE: api/bookings/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
