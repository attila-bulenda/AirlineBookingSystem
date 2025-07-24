using AirlineBookingSystem.Invoices.Application.Commands;
using AirlineBookingSystem.Invoices.Core.Interfaces;
using MediatR;

namespace AirlineBookingSystem.Invoices.Application.Handlers
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        private readonly IInvoicesRepository _repository;
        public DeleteInvoiceHandler(IInvoicesRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _repository.GetAsync(request.id);
            if (invoice == null)
            {
                throw new KeyNotFoundException();
            }
            await _repository.DeleteAsync(request.id);
        }
    }
}

