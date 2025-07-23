using AirlineBookingSystem.Users.Core.DTOs;
using AirlineBookingSystem.Users.Core.Models;
using AutoMapper;

namespace AirlineBookingSystem.Users.Application.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<SystemUser, RegisterUserDto>().ReverseMap();
            CreateMap<SystemUser, UserResponseDto>().ReverseMap();
        }
    }
}
