using NotificationUtils = AirlineBookingSystem.Notifications.Application.Notifications.Notifications;
using Contracts.Messages;
using MassTransit;

namespace AirlineBookingSystem.Notifications.Application.Consumers
{
    public class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
    {
        public async Task Consume(ConsumeContext<UserDeletedEvent> context)
        {
            var message = context.Message;
            NotificationUtils.UserDeletionNotification(message.email);
            await Task.CompletedTask;
        }
    }
}
