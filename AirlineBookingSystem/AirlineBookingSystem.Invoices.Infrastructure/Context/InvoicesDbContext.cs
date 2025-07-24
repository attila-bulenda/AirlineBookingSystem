using AirlineBookingSystem.Invoices.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Invoices.Infrastructure.Context
{
    public class InvoicesDbContext: DbContext
    {
        public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
