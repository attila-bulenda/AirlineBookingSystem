using NotificationUtils = AirlineBookingSystem.Notifications.Application.Notifications.Notifications;
using Contracts.Messages;
using MassTransit;

namespace AirlineBookingSystem.Notifications.Application.Consumers
{
    public class FlightUpdatedConsumer : IConsumer<FlightUpdatedEvent>
    {
        public async Task Consume(ConsumeContext<FlightUpdatedEvent> context)
        {
            var message = context.Message;
            NotificationUtils.FlightUpdateNotification(message.flight);
            await Task.CompletedTask;
        }
    }
}
