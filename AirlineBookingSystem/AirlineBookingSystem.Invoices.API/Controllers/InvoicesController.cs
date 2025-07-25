using AirlineBookingSystem.Invoices.Application.Commands;
using AirlineBookingSystem.Invoices.Application.Queries;
using AirlineBookingSystem.Invoices.Core.DTOs;
using AirlineBookingSystem.Invoices.Core.Models;
using AirlineBookingSystem.Invoices.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Invoices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoicesDbContext _context;
        private readonly IMediator _mediator;

        public InvoicesController(InvoicesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice(int id)
        {
            var invoice = await _mediator.Send(new GetInvoiceQuery(id));
            return invoice is null ? NotFound() : Ok(invoice);
        }

        // POST: api/invoices
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] InvoiceDto invoice)
        {
            var newInvoice = _mediator.Send(new CreateInvoiceCommand(invoice));
            return CreatedAtAction(nameof(GetInvoice), new { id = newInvoice.Id }, invoice);
        }

        // DELETE: api/invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            await _mediator.Send(new DeleteInvoiceCommand(id));
            return NoContent();
        }
    }
}
