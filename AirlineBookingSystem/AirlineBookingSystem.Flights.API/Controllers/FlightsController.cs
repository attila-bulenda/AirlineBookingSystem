using AirlineBookingSystem.Flights.Application.Commands.Flights;
using AirlineBookingSystem.Flights.Application.Queries.Flights;
using AirlineBookingSystem.Flights.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Flights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/flights
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FlightDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FlightDetailsDto>>> GetFlights()
        {
            var flights = await _mediator.Send(new GetAllFlightsQuery());
            return flights is null ? NotFound() : Ok(flights);
        }

        // GET: api/flights/detailed
        [HttpGet("detailed")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(IEnumerable<FlightDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<FlightDetailsDto>>> GetFlightsDetailed()
        {
            var flights = await _mediator.Send(new GetAllFlightsWithBookingsQuery());
            return flights is null ? NotFound() : Ok(flights);
        }

        // GET: api/flights/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FlightDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlightDto>> GetFlight(int id)
        {
            var flight = await _mediator.Send(new GetFlightQuery(id));
            return flight is null ? NotFound() : Ok(flight);
        }

        // PUT: api/flights/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateFlight(int id, FlightDto flight)
        {
            var result = await _mediator.Send(new UpdateFlightCommand(id, flight));
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

        // POST: api/flights
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(FlightDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<FlightDto>> CreateFlight(FlightDto flight)
        {
            var flightId = await _mediator.Send(new CreateFlightCommand(flight));
            return CreatedAtAction("GetFlight", new { id = flightId }, flight);
        }

        // DELETE: api/flights/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var result = await _mediator.Send(new DeleteFlightCommand(id));
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
