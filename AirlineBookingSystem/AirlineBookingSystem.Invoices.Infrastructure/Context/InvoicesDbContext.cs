using AirlineBookingSystem.Invoices.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AirlineBookingSystem.Invoices.Infrastructure.Context
{
    public class InvoicesDbContext: DbContext
    {
        public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
