using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Application.Queries;
using AirlineBookingSystem.Users.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlineBookingSystem.Users.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private const string role = "User";

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/users/register
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> RegisterUser([FromBody] RegisterUserDto user)
        {
            var createdUser = await _mediator.Send(new RegisterUserCommand(user, role));
            return CreatedAtAction(nameof(GetMyProfile), new { id = createdUser.Id }, createdUser);
        }

        // POST: api/users/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto credentials)
        {
            var result = await _mediator.Send(new LoginUserCommand(credentials));
            return Ok(result);
        }

        // GET: api/profile
        [HttpGet("profile")]
        public async Task<ActionResult<UserResponseDto>> GetMyProfile()
        {
            string userId = User.FindFirst("uid")?.Value;
            var user = await _mediator.Send(new GetUserInfoQuery(userId));
            return user == null ? NotFound() : Ok(user);
        }

        // PUT: api/profile
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] SystemUserDto user)
        {
            string userId = User.FindFirst("uid")?.Value;
            await _mediator.Send(new UpdateUserCommand(userId, user));
            return NoContent();
        }

        // DELETE: api/profile
        [HttpDelete]
        public async Task<IActionResult> DeleteMyProfile()
        {
            string userId = User.FindFirst("uid")?.Value;
            // await _mediator.Send(new DeleteUserCommand(userId));
            return NoContent();
        }
    }
}
