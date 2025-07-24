using AirlineBookingSystem.Invoices.Application.Commands;
using AirlineBookingSystem.Invoices.Core.Interfaces;
using AirlineBookingSystem.Invoices.Core.Models;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Invoices.Application.Handlers
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
    {
        private readonly IInvoicesRepository _invoicesRepository;
        private readonly IMapper _mapper;
        public CreateInvoiceHandler(IInvoicesRepository invoicesRepository, IMapper mapper)
        {
            _invoicesRepository = invoicesRepository;
            _mapper = mapper;
        }
        public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(request.invoice);
            if (invoice is null)
            {
                throw new InvalidOperationException("Failed to map invoice from request.");
            }
            await _invoicesRepository.AddAsync(invoice);
            return invoice;
        }
    }
}
