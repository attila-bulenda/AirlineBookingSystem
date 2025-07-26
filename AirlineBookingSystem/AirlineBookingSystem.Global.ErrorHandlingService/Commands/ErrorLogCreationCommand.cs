using MediatR;

namespace AirlineBookingSystem.Global.ErrorHandlingService.Commands
{
    public record ErrorLogCreationCommand(string message): IRequest;
}
