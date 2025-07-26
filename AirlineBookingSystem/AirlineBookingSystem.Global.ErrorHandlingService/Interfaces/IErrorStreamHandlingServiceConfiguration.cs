namespace AirlineBookingSystem.Global.ErrorHandlingService.Interfaces
{
    public interface IErrorStreamHandlingServiceConfiguration
    {
        public Task CreateErrorhandlingStream();
        public Task LogErrorToStream(string message);
    }
}
