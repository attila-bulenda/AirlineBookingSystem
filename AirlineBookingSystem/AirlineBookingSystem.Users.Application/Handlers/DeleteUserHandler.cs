using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Core.Models;
using Contracts.Messages;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Application.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly IPublishEndpoint _publishEndpoint;
        public DeleteUserHandler(UserManager<SystemUser> userManager, IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user is not null)
            {
                await _userManager.DeleteAsync(user);
                await _publishEndpoint.Publish(new UserDeletedEvent(user.Email));
            }
        }
    }
}
