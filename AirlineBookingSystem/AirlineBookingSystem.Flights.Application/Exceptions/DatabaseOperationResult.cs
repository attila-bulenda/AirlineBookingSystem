namespace AirlineBookingSystem.Flights.Application.Exceptions
{
    public class DatabaseOperationResult
    {
        public bool Success { get; set; }
        public bool NotFound { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
