using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Application.Queries;
using AirlineBookingSystem.Users.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Users.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponseDto>> RegisterUser([FromBody] RegisterUserDto user)
        {
            var createdUser = await _mediator.Send(new RegisterUserCommand(user, role));
            return CreatedAtAction(nameof(GetMyProfile), new { id = createdUser.Id }, createdUser);
        }

        // POST: api/users/login
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticationResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginDto credentials)
        {
            var result = await _mediator.Send(new LoginUserCommand(credentials));
            return result is null ? Unauthorized("Invalid credentials.") : Ok(result);
        }

        // GET: api/users/profile
        [HttpGet("profile")]
        [Authorize(Roles = "Administrator, User")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserResponseDto>> GetMyProfile()
        {
            string userId = User.FindFirst("uid")?.Value;
            var user = await _mediator.Send(new GetUserInfoQuery(userId));
            return user == null ? NotFound() : Ok(user);
        }

        // PUT: api/users/profile
        [HttpPut("profile")]
        [Authorize(Roles = "Administrator, User")]
        [Authorize(Roles = "Administrator, User")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateMyProfile([FromBody] SystemUserDto user)
        {
            string userId = User.FindFirst("uid")?.Value;
            await _mediator.Send(new UpdateUserCommand(userId, user));
            return NoContent();
        }

        // DELETE: api/users/profile
        [HttpDelete("profile")]
        [Authorize(Roles = "Administrator, User")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteMyProfile()
        {
            string userId = User.FindFirst("uid")?.Value;
            await _mediator.Send(new DeleteUserCommand(userId));
            return NoContent();
        }
    }
}
