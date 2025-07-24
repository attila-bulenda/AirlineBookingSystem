using AirlineBookingSystem.Users.Application.Commands;
using AirlineBookingSystem.Users.Application.Queries;
using AirlineBookingSystem.Users.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Users.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
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
        public async Task<ActionResult<UserResponseDto>> RegisterUser([FromBody] RegisterUserDto user, string role)
        {
            var createdUser = await _mediator.Send(new RegisterUserCommand(user, role));
            return CreatedAtAction(nameof(GetMyProfile), new { id = createdUser.Id }, createdUser);
        }

        // GET: api/profile/f3d90f8e-43da-4389-85f4-9dfaeb6c99dc
        [HttpGet("profile/{id}")]
        public async Task<ActionResult<UserResponseDto>> GetMyProfile(string id)
        {
            var user = await _mediator.Send(new GetUserInfoQuery(id));
            return user == null ? NotFound() : Ok(user);
        }

        // PUT: api/profile/f3d90f8e-43da-4389-85f4-9dfaeb6c99dc
        [HttpPut("profile/{id}")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] SystemUserDto user, string id)
        {
            await _mediator.Send(new UpdateUserCommand(id, user));
            return NoContent();
        }

        // DELETE: api/profile/f3d90f8e-43da-4389-85f4-9dfaeb6c99dc
        [HttpDelete("profile/{id}")]
        public async Task<IActionResult> DeleteMyProfile(string id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}
