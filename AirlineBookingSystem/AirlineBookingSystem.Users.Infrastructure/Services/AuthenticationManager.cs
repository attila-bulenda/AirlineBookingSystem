using AirlineBookingSystem.Users.Core.DTOs;
using AirlineBookingSystem.Users.Core.Interfaces;
using AirlineBookingSystem.Users.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AirlineBookingSystem.Users.Infrastructure.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationManager(IMapper mapper, UserManager<SystemUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<UserResponseDto> Register(RegisterUserDto details, string role = "User")
        {
            var user = _mapper.Map<SystemUser>(details);
            var result = await _userManager.CreateAsync(user, details.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<AuthenticationResponseDto> Login(LoginDto credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (user == null || isValidUser == false)
            {
                return null;
            }
            var token = await GenerateToken(user);
            return new AuthenticationResponseDto
            {
                Id = user.Id,
                Token = token,
            };
        }

        private async Task<string> GenerateToken(SystemUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim("uid", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
