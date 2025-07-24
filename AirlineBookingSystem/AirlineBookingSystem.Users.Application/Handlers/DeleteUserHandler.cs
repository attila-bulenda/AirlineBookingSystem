using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Application.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<SystemUser> _userManager;
        public DeleteUserHandler(UserManager<SystemUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user is not null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
    }
}
