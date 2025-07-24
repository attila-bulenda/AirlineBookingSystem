using AirlineBookingSystem.Invoices.Application.Commands;
using Contracts.Messages;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Invoices.Application.Consumers
{
    public class BookingCreatedConsumer : IConsumer<BookingCreatedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMediator _mediator;
        public BookingCreatedConsumer(IPublishEndpoint publishEndpoint, IMediator mediator)
        {
            _publishEndpoint = publishEndpoint;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<BookingCreatedEvent> context)
        {
            var invoice = context.Message.invoice;
            await _mediator.Send(new CreateInvoiceCommand(invoice));
            await _publishEndpoint.Publish(new InvoiceCreatedEvent(invoice.FlightNumber, invoice.CustomerEmail));
        }
    }
}
