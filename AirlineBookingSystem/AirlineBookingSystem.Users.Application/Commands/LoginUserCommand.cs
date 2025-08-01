﻿using AirlineBookingSystem.Users.Core.DTOs;
using MediatR;

namespace AirlineBookingSystem.Users.Application.Commands
{
    public record LoginUserCommand(LoginDto credentials): IRequest<AuthenticationResponseDto>;
}
