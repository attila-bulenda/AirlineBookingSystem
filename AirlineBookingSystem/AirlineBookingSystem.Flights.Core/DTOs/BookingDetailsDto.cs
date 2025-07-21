namespace AirlineBookingSystem.Flights.Core.DTOs
{
    public class BookingDetailsDto: BookingDto
    {
        public FlightDto Flight { get; set; }
    }
}
