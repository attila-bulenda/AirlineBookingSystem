using AirlineBookingSystem.Global.ErrorHandlingService.Interfaces;

namespace AirlineBookingSystem.Global.ErrorHandlingService
{
    public class Worker : BackgroundService
    {
        private readonly IErrorStreamHandlingServiceConfiguration _streamService;

        public Worker(IErrorStreamHandlingServiceConfiguration streamService)
        {
            _streamService = streamService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _streamService.CreateErrorhandlingStream();

            Console.WriteLine("Stream initialized. Listening...");
            return Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
