using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Core.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Application.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly IMapper _mapper;
        public UpdateUserHandler(UserManager<SystemUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user is not null)
            {
                _mapper.Map(request.user, user);
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
