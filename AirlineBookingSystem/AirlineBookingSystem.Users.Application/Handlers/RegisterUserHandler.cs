using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Core.DTOs;
using AirlineBookingSystem.Users.Core.Interfaces;
using Contracts.Messages;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Users.Application.Handlers
{
    internal class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserResponseDto>
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IPublishEndpoint _publishEndpoint;
        public RegisterUserHandler(IAuthenticationManager authenticationManager, IPublishEndpoint publishEndpoint)
        {
            _authenticationManager = authenticationManager;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<UserResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationManager.Register(request.user, request.role);
            await _publishEndpoint.Publish(new UserCreatedEvent(user.Email));
            return user;
        }
    }
}
