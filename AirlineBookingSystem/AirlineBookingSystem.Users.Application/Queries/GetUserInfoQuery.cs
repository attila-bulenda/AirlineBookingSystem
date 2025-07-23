using AirlineBookingSystem.Users.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Users.Application.Queries
{
    public record GetUserInfoQuery(string id): IRequest<UserResponseDto>;
}
