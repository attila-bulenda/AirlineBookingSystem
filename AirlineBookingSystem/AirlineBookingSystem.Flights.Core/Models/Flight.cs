using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem.Flights.Core.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightCode { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string? AircraftType { get; set; }

        public List<Booking>? Bookings { get; set; }

        [ConcurrencyCheck]
        public Guid Version { get; set; }
    }
}
