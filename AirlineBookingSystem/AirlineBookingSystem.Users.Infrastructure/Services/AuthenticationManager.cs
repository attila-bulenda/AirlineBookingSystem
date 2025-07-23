using AirlineBookingSystem.Users.Core.DTOs;
using AirlineBookingSystem.Users.Core.Interfaces;
using AirlineBookingSystem.Users.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Infrastructure.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SystemUser> _userManager;

        public AuthenticationManager(IMapper mapper, UserManager<SystemUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<UserResponseDto> Register(RegisterUserDto details)
        {
            var user = _mapper.Map<SystemUser>(details);
            var result = await _userManager.CreateAsync(user, details.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
