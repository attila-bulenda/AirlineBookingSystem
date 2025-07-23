using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Core.DTOs;
using AirlineBookingSystem.Users.Core.Interfaces;
using MediatR;

namespace AirlineBookingSystem.Users.Application.Handlers
{    
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthenticationResponseDto>
    {
        private readonly IAuthenticationManager _manager;
        public LoginUserHandler(IAuthenticationManager manager)
        {
            _manager = manager;
        }
        public async Task<AuthenticationResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _manager.Login(request.credentials);
        }
    }
}
