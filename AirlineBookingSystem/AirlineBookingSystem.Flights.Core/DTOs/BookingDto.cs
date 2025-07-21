using AirlineBookingSystem.Flights.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights.Core.DTOs
{
    public class BookingDto
    {
        public string PassengerName { get; set; }
        public string PassportNumber { get; set; }
        public string SeatNumber { get; set; }
    }
}
