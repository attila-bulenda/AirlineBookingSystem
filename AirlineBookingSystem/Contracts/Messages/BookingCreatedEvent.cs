using AirlineBookingSystem.Invoices.Core.DTOs;

namespace Contracts.Messages
{
    public record BookingCreatedEvent(InvoiceDto invoice);
}
