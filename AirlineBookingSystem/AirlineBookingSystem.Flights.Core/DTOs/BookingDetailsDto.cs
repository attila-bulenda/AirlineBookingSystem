using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights.Core.DTOs
{
    public class BookingDetailsDto: BookingDto
    {
        public FlightDto Flight { get; set; }
    }
}
