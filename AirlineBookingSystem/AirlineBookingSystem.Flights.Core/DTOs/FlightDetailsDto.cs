namespace AirlineBookingSystem.Flights.Core.DTOs
{
    public class FlightDetailsDto: FlightDto
    {
        public List<BookingDto>? Bookings { get; set; }
    }
}
