using AirlineBookingSystem.Global.ErrorHandlingService.Commands;
using AirlineBookingSystem.Global.ErrorHandlingService.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Users.API.Controllers
{
    [Route("error")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ErrorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("uncaught-exception")]
        public async Task<IActionResult> HandleError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;
            var instance = HttpContext.Request.Path.Value;
            var json = ModelFormatter.JSONFormatProblemDetailsModel(exception, instance);
            await _mediator.Send(new ErrorLogCreationCommand(json));
            return new ObjectResult(json);
        }
    }
}
