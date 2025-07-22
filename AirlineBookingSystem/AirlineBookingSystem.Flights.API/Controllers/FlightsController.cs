using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirlineBookingSystem.Flights.Infrastructure.Context;
using AirlineBookingSystem.Flights.Core.Models;
using MediatR;
using AirlineBookingSystem.Flights.Application.Queries.Flights;
using AirlineBookingSystem.Flights.Core.DTOs;

namespace AirlineBookingSystem.Flights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly FlightsDbContext _context;
        private readonly IMediator _mediator;

        public FlightsController(FlightsDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDetailsDto>>> GetFlights()
        {
            var flights = await _mediator.Send(new GetAllFlightsQuery());
            return flights is null ? NotFound() : Ok(flights);
        }

        // GET: api/Flights/Detailed
        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<FlightDetailsDto>>> GetFlightsDetailed()
        {
            var flights = await _mediator.Send(new GetAllFlightsWithBookingsQuery());
            return flights is null ? NotFound() : Ok(flights);
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDto>> GetFlight(int id)
        {
            var flight = await _mediator.Send(new GetFlightQuery(id));
            return flight is null ? NotFound() : Ok(flight);
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}
