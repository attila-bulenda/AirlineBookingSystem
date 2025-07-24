using NotificationUtils = AirlineBookingSystem.Notifications.Application.Notifications.Notifications;
using Contracts.Messages;
using MassTransit;

namespace AirlineBookingSystem.Notifications.Application.Consumers
{
    public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
    {
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var message = context.Message;
            NotificationUtils.UserRegistrationNotification(message.email);
            await Task.CompletedTask;
        }
    }
}
