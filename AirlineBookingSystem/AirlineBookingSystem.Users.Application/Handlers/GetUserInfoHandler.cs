using AirlineBookingSystem.Users.Application.Queries;
using AirlineBookingSystem.Users.Core.DTOs;
using AirlineBookingSystem.Users.Core.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Application.Handlers
{
    internal class GetUserInfoHandler : IRequestHandler<GetUserInfoQuery, UserResponseDto>
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly IMapper _mapper;
        public GetUserInfoHandler(UserManager<SystemUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
