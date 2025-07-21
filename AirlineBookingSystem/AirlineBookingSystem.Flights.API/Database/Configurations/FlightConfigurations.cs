using AirlineBookingSystem.Flights.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineBookingSystem.Flights.API.Database.Configurations
{
    internal class FlightConfigurations: IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasData
            (
                new Flight
                {
                    Id = 1,
                    FlightCode = "DY1550",
                    Departure = new DateTime(2025, 10, 12, 14, 30, 0),
                    Arrival = new DateTime(2025, 10, 12, 16, 45, 0),
                    DepartureAirportCode = "OSL",
                    ArrivalAirportCode = "BUD",
                    AircraftType = "Boeing 737-800"
                },
                new Flight
                {
                    Id = 2,
                    FlightCode = "LH2021",
                    Departure = new DateTime(2025, 10, 13, 9, 15, 0),
                    Arrival = new DateTime(2025, 10, 13, 11, 0, 0), 
                    DepartureAirportCode = "FRA",
                    ArrivalAirportCode = "AMS",
                    AircraftType = "Airbus A320"
                },
                new Flight
                {
                    Id = 3,
                    FlightCode = "AF1133",
                    Departure = new DateTime(2025, 11, 1, 17, 45, 0),
                    Arrival = new DateTime(2025, 11, 1, 19, 30, 0), 
                    DepartureAirportCode = "CDG",
                    ArrivalAirportCode = "MAD",
                    AircraftType = "Airbus A321"
                },
                new Flight
                {
                    Id = 4,
                    FlightCode = "BA804",
                    Departure = new DateTime(2025, 11, 5, 6, 0, 0),
                    Arrival = new DateTime(2025, 11, 5, 9, 5, 0), 
                    DepartureAirportCode = "LHR",
                    ArrivalAirportCode = "ARN",
                    AircraftType = "Boeing 777"
                },
                new Flight
                {
                    Id = 5,
                    FlightCode = "SK1502",
                    Departure = new DateTime(2025, 10, 20, 12, 30, 0),
                    Arrival = new DateTime(2025, 10, 20, 13, 40, 0), 
                    DepartureAirportCode = "OSL",
                    ArrivalAirportCode = "CPH",
                    AircraftType = "Airbus A220"
                },
                new Flight
                {
                    Id = 6,
                    FlightCode = "AY432",
                    Departure = new DateTime(2025, 11, 8, 10, 10, 0),
                    Arrival = new DateTime(2025, 11, 8, 12, 40, 0), 
                    DepartureAirportCode = "HEL",
                    ArrivalAirportCode = "MUC",
                    AircraftType = "Embraer 190"
                },
                new Flight
                {
                    Id = 7,
                    FlightCode = "TK1891",
                    Departure = new DateTime(2025, 12, 2, 21, 45, 0),
                    Arrival = new DateTime(2025, 12, 3, 0, 30, 0),
                    DepartureAirportCode = "IST",
                    ArrivalAirportCode = "FCO",
                    AircraftType = "Boeing 737 MAX 8"
                },
                new Flight
                {
                    Id = 8,
                    FlightCode = "KLM1187",
                    Departure = new DateTime(2025, 10, 27, 13, 20, 0),
                    Arrival = new DateTime(2025, 10, 27, 15, 10, 0), 
                    DepartureAirportCode = "AMS",
                    ArrivalAirportCode = "OSL",
                    AircraftType = "Embraer 175"
                },
                new Flight
                {
                    Id = 9,
                    FlightCode = "W61302",
                    Departure = new DateTime(2025, 11, 3, 7, 10, 0),
                    Arrival = new DateTime(2025, 11, 3, 9, 0, 0), 
                    DepartureAirportCode = "BUD",
                    ArrivalAirportCode = "LTN",
                    AircraftType = "Airbus A321neo"
                },
                new Flight
                {
                    Id = 10,
                    FlightCode = "LO285",
                    Departure = new DateTime(2025, 11, 10, 18, 0, 0),
                    Arrival = new DateTime(2025, 11, 10, 20, 10, 0), 
                    DepartureAirportCode = "WAW",
                    ArrivalAirportCode = "ZRH",
                    AircraftType = "Boeing 737-800"
                },
                new Flight
                {
                    Id = 11,
                    FlightCode = "IB3517",
                    Departure = new DateTime(2025, 10, 30, 15, 50, 0),
                    Arrival = new DateTime(2025, 10, 30, 17, 10, 0), 
                    DepartureAirportCode = "BCN",
                    ArrivalAirportCode = "LIS",
                    AircraftType = "Airbus A320"
                },
                new Flight
                {
                    Id = 12,
                    FlightCode = "AZ6051",
                    Departure = new DateTime(2025, 12, 12, 22, 15, 0),
                    Arrival = new DateTime(2025, 12, 13, 0, 55, 0), 
                    DepartureAirportCode = "FCO",
                    ArrivalAirportCode = "ATH",
                    AircraftType = "Airbus A319"
                },
                new Flight
                {
                    Id = 13,
                    FlightCode = "LX1624",
                    Departure = new DateTime(2025, 11, 14, 8, 40, 0),
                    Arrival = new DateTime(2025, 11, 14, 10, 25, 0), 
                    DepartureAirportCode = "ZRH",
                    ArrivalAirportCode = "VIE",
                    AircraftType = "Bombardier CS300"
                },
                new Flight
                {
                    Id = 14,
                    FlightCode = "EZY4283",
                    Departure = new DateTime(2025, 10, 31, 5, 55, 0),
                    Arrival = new DateTime(2025, 10, 31, 8, 10, 0), 
                    DepartureAirportCode = "LGW",
                    ArrivalAirportCode = "FRA",
                    AircraftType = "Airbus A320neo"
                },
                new Flight
                {
                    Id = 15,
                    FlightCode = "DY1963",
                    Departure = new DateTime(2025, 11, 18, 16, 10, 0),
                    Arrival = new DateTime(2025, 11, 18, 18, 40, 0), 
                    DepartureAirportCode = "OSL",
                    ArrivalAirportCode = "CDG",
                    AircraftType = "Boeing 737-800"
                }


            );
        }      

    }
}
