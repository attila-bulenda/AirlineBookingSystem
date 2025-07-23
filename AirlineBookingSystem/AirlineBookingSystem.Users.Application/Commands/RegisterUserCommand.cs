using AirlineBookingSystem.Users.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Application.Commands
{
    public record RegisterUserCommand(RegisterUserDto user, string role) : IRequest<UserResponseDto>;
}
