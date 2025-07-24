using AirlineBookingSystem.Invoices.Core.DTOs;
using AirlineBookingSystem.Invoices.Core.Models;
using MediatR;

namespace AirlineBookingSystem.Invoices.Application.Commands
{
    public record CreateInvoiceCommand(InvoiceDto invoice): IRequest<Invoice>;
}
