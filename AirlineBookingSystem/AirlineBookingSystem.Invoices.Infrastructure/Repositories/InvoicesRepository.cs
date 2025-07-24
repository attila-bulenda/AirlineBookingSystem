using AirlineBookingSystem.Invoices.Core.Interfaces;
using AirlineBookingSystem.Invoices.Core.Models;
using AirlineBookingSystem.Invoices.Infrastructure.Context;

namespace AirlineBookingSystem.Invoices.Infrastructure.Repositories
{
    public class InvoicesRepository: GenericRepository<Invoice>, IInvoicesRepository
    {
        private readonly InvoicesDbContext _context;
        public InvoicesRepository(InvoicesDbContext context): base(context)
        {
            _context = context;
        }
    }
}
