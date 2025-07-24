using AirlineBookingSystem.Invoices.Application.Queries;
using AirlineBookingSystem.Invoices.Core.DTOs;
using AirlineBookingSystem.Invoices.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Invoices.Application.Handlers
{
    internal class GetInvoiceHandler : IRequestHandler<GetInvoiceQuery, InvoiceDto>
    {
        private readonly IInvoicesRepository _invoicesRepository;
        private readonly IMapper _mapper;
        public GetInvoiceHandler(IInvoicesRepository invoicesRepository, IMapper mapper)
        {
            _invoicesRepository = invoicesRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoicesRepository.GetAsync(request.id);
            if (invoice == null)
            {
                throw new KeyNotFoundException($"Invoice with ID {request.id} was not found.");
            }
            return _mapper.Map<InvoiceDto>(invoice);
        }
    }
}
