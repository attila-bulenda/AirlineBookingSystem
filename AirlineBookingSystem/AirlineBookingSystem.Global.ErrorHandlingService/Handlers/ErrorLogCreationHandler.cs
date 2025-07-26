using AirlineBookingSystem.Global.ErrorHandlingService.Commands;
using AirlineBookingSystem.Global.ErrorHandlingService.Interfaces;
using MediatR;

namespace AirlineBookingSystem.Global.ErrorHandlingService.Handlers
{
    public class ErrorLogCreationHandler : IRequestHandler<ErrorLogCreationCommand>
    {
        private readonly IErrorStreamHandlingServiceConfiguration _streamService;

        public ErrorLogCreationHandler(IErrorStreamHandlingServiceConfiguration streamService)
        {
            _streamService = streamService;
        }

        public async Task Handle(ErrorLogCreationCommand request, CancellationToken cancellationToken)
        {
            await _streamService.LogErrorToStream(request.message);
        }
    }
}
