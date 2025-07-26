using AirlineBookingSystem.Global.ErrorHandlingService.Commands;
using AirlineBookingSystem.Global.ErrorHandlingService.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace AirlineBookingSystem.Flights.API.Controllers
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
            var details = new StructuredProblemDetails
            {
                Title = exception.Message,
                DetailLines = exception.StackTrace?
                    .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList() ?? [],
                Instance = HttpContext.Request.Path
            };
            var json = JsonSerializer.Serialize(details, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await _mediator.Send(new ErrorLogCreationCommand(json));
            return new ObjectResult(details);
        }
    }
}
