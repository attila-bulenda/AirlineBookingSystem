using MediatR;

namespace AirlineBookingSystem.Users.Application.Commands
{
    public record DeleteUserCommand(string id): IRequest;
}
