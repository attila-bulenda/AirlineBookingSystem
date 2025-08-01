﻿namespace AirlineBookingSystem.Flights.Core.DTOs
{
    public class FlightDto
    {
        public string FlightCode { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string? AircraftType { get; set; }
    }
}
