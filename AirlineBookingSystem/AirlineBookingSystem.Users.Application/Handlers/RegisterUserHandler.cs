using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Core.DTOs;
using AirlineBookingSystem.Users.Core.Interfaces;
using MediatR;

namespace AirlineBookingSystem.Users.Application.Handlers
{
    internal class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserResponseDto>
    {
        private readonly IAuthenticationManager _authenticationManager; 
        public RegisterUserHandler(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        public async Task<UserResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationManager.Register(request.user);
            return user;
        }
    }
}
