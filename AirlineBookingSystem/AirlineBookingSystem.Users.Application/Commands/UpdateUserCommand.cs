using AirlineBookingSystem.Users.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Users.Application.Commands
{
    public record UpdateUserCommand(string id, SystemUserDto user) : IRequest;
}
