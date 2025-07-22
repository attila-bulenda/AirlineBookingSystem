using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Models;
using AutoMapper;

namespace AirlineBookingSystem.Flights.Application.Configurations
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
           CreateMap<Flight, FlightDto>().ReverseMap();
           CreateMap<Flight, FlightDetailsDto>().ReverseMap();
           CreateMap<Booking, BookingDto>().ReverseMap();
           CreateMap<Booking, BookingDetailsDto>().ReverseMap();
        }
    }
}
