using RabbitMQ.Stream.Client;
using RabbitMQ.Stream.Client.Reliable;
using System.Text;

namespace AirlineBookingSystem.Global.ErrorHandlingService.Consumers
{
    public class ErrorStreamConsumerService: BackgroundService
    {
        private Consumer? _consumer;
        private StreamSystem? _streamSystem;
        private const string StreamName = "error-stream";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _streamSystem ??= await StreamSystem.Create(new StreamSystemConfig());
            _consumer = await Consumer.Create(new ConsumerConfig(_streamSystem, StreamName)
            {
                OffsetSpec = new OffsetTypeFirst(),
                MessageHandler = async (stream, ctx, consumer, message) =>
                {
                    var msgBody = Encoding.UTF8.GetString(message.Data.Contents);
                    Console.WriteLine($"[Consumer] Received from stream '{stream}':");
                    Console.WriteLine($"{msgBody}");
                    await Task.CompletedTask;
                }
            });
            Console.WriteLine("[Consumer] Started listening to error-stream...");
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_consumer != null) await _consumer.Close();
            if (_streamSystem != null) await _streamSystem.Close();
        }
    }
}
