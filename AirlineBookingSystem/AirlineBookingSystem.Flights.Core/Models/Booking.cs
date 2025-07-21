using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem.Flights.Core.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string PassportNumber { get; set; }
        public string SeatNumber { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        [ConcurrencyCheck]
        public Guid Version { get; set; }
    }
}
