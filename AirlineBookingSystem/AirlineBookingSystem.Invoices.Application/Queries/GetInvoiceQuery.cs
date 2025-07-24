using AirlineBookingSystem.Invoices.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Invoices.Application.Queries
{
    public record GetInvoiceQuery(int id): IRequest<InvoiceDto>;
}
