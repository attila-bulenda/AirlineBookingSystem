using NotificationUtils = AirlineBookingSystem.Notifications.Application.Notifications.Notifications;
using Contracts.Messages;
using MassTransit;

namespace AirlineBookingSystem.Notifications.Application.Consumers
{
    public class InvoiceCreatedConsumer : IConsumer<InvoiceCreatedEvent>
    {
        public async Task Consume(ConsumeContext<InvoiceCreatedEvent> context)
        {
            var message = context.Message;
            NotificationUtils.FlightBookingNotification(message.email, message.flight);
            await Task.CompletedTask;
        }
    }
}
