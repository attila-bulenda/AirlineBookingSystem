using MediatR;

namespace AirlineBookingSystem.Invoices.Application.Commands
{
    public record DeleteInvoiceCommand(int id): IRequest;
}
