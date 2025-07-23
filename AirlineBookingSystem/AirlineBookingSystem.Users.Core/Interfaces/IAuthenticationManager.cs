using AirlineBookingSystem.Users.Core.DTOs;

namespace AirlineBookingSystem.Users.Core.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<UserResponseDto> Register(RegisterUserDto details);
        Task<AuthenticationResponseDto> Login(LoginDto credentials);
    }
}
