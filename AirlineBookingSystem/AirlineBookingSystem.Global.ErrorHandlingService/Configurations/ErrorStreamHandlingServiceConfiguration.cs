using AirlineBookingSystem.Global.ErrorHandlingService.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Stream.Client;
using RabbitMQ.Stream.Client.Reliable;
using System.Net;
using System.Text;

namespace AirlineBookingSystem.Global.ErrorHandlingService.Configurations
{
    public class ErrorStreamHandlingServiceConfiguration : IErrorStreamHandlingServiceConfiguration
    {
        private StreamSystem? _streamSystem;
        private Producer? _producer;
        private const string StreamName = "error-stream";
        private readonly string _hostAddress;

        public ErrorStreamHandlingServiceConfiguration(IOptions<EventBusSettings> settings)
        {
            _hostAddress = settings.Value.HostAddress;
        }
        public async Task CreateErrorhandlingStream()
        {
            var uri = new Uri(_hostAddress);
            var streamHost = uri.Host;

            _streamSystem ??= await StreamSystem.Create(new StreamSystemConfig
            {
                UserName = uri.UserInfo.Split(':')[0],
                Password = uri.UserInfo.Split(':')[1],
                Endpoints = new List<EndPoint>
            {
                new DnsEndPoint(streamHost, 5552)
            }
            });

            var exists = await _streamSystem.StreamExists(StreamName);
            if (!exists)
            {
                await _streamSystem.CreateStream(new StreamSpec(StreamName)
                {
                    MaxLengthBytes = 5_000_000_000
                });
            }

            _producer ??= await Producer.Create(new ProducerConfig(_streamSystem, StreamName));
        }

        public async Task LogErrorToStream(string message)
        {
            if (_producer == null)
            {
                await CreateErrorhandlingStream();
            }
            var msg = new Message(Encoding.UTF8.GetBytes(message));
            await _producer.Send(msg);
        }
    }
}
