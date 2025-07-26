using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Application.Queries;
using AirlineBookingSystem.Users.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace AirlineBookingSystem.Users.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/users/register/Administrator
        // POST: api/users/register/User
        [HttpPost("register/{role}")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserResponseDto>> RegisterUser([FromBody] RegisterUserDto user, string role)
        {
            var createdUser = await _mediator.Send(new RegisterUserCommand(user, role));
            return CreatedAtAction(nameof(GetProfile), new { id = createdUser.Id }, createdUser);
        }

        // GET: api/profile/f3d90f8e-43da-4389-85f4-9dfaeb6c99dc
        [HttpGet("profile/{id}")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserResponseDto>> GetProfile(string id)
        {
            var user = await _mediator.Send(new GetUserInfoQuery(id));
            return user == null ? NotFound() : Ok(user);
        }

        // PUT: api/profile/f3d90f8e-43da-4389-85f4-9dfaeb6c99dc
        [HttpPut("profile/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateProfile([FromBody] SystemUserDto user, string id)
        {
            await _mediator.Send(new UpdateUserCommand(id, user));
            return NoContent();
        }

        // DELETE: api/profile/f3d90f8e-43da-4389-85f4-9dfaeb6c99dc
        [HttpDelete("profile/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteProfile(string id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}
