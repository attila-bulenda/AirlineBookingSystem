using AirlineBookingSystem.Flights.Core.Models;
using AirlineBookingSystem.Invoices.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AirlineBookingSystem.Invoices.Infrastructure.Configurations
{
    public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData
            (
                new Invoice { Id = 1, Amount = 199.99m, PaymentDate = new DateTime(2025, 10, 12, 14, 30, 0), CustomerName = "Alice Smith", CustomerEmail = "user1@example.com", FlightNumber = "DY1550" },
                new Invoice { Id = 2, Amount = 149.50m, PaymentDate = new DateTime(2025, 10, 13, 9, 15, 0), CustomerName = "Bob Johnson", CustomerEmail = "user2@example.com", FlightNumber = "LH2021" },
                new Invoice { Id = 3, Amount = 275.20m, PaymentDate = new DateTime(2025, 11, 1, 17, 45, 0), CustomerName = "Charlie Williams", CustomerEmail = "user3@example.com", FlightNumber = "AF1133" },
                new Invoice { Id = 4, Amount = 189.00m, PaymentDate = new DateTime(2025, 11, 5, 6, 0, 0), CustomerName = "Diana Brown", CustomerEmail = "user4@example.com", FlightNumber = "BA804" },
                new Invoice { Id = 5, Amount = 129.45m, PaymentDate = new DateTime(2025, 10, 20, 12, 30, 0), CustomerName = "Ethan Jones", CustomerEmail = "user5@example.com", FlightNumber = "SK1502" },
                new Invoice { Id = 6, Amount = 215.80m, PaymentDate = new DateTime(2025, 11, 8, 10, 10, 0), CustomerName = "Fiona Garcia", CustomerEmail = "user6@example.com", FlightNumber = "AY432" },
                new Invoice { Id = 7, Amount = 305.00m, PaymentDate = new DateTime(2025, 12, 2, 21, 45, 0), CustomerName = "George Martinez", CustomerEmail = "user7@example.com", FlightNumber = "TK1891" },
                new Invoice { Id = 8, Amount = 170.10m, PaymentDate = new DateTime(2025, 10, 27, 13, 20, 0), CustomerName = "Hannah Davis", CustomerEmail = "user8@example.com", FlightNumber = "KLM1187" },
                new Invoice { Id = 9, Amount = 112.75m, PaymentDate = new DateTime(2025, 11, 3, 7, 10, 0), CustomerName = "Ian Rodriguez", CustomerEmail = "user9@example.com", FlightNumber = "W61302" },
                new Invoice { Id = 10, Amount = 225.30m, PaymentDate = new DateTime(2025, 11, 10, 18, 0, 0), CustomerName = "Julia Lopez", CustomerEmail = "user10@example.com", FlightNumber = "LO285" },
                new Invoice { Id = 11, Amount = 160.00m, PaymentDate = new DateTime(2025, 10, 30, 15, 50, 0), CustomerName = "Alice Smith", CustomerEmail = "user1@example.com", FlightNumber = "IB3517" },
                new Invoice { Id = 12, Amount = 198.88m, PaymentDate = new DateTime(2025, 12, 12, 22, 15, 0), CustomerName = "Bob Johnson", CustomerEmail = "user2@example.com", FlightNumber = "AZ6051" },
                new Invoice { Id = 13, Amount = 142.60m, PaymentDate = new DateTime(2025, 11, 14, 8, 40, 0), CustomerName = "Charlie Williams", CustomerEmail = "user3@example.com", FlightNumber = "LX1624" },
                new Invoice { Id = 14, Amount = 134.00m, PaymentDate = new DateTime(2025, 10, 31, 5, 55, 0), CustomerName = "Diana Brown", CustomerEmail = "user4@example.com", FlightNumber = "EZY4283" },
                new Invoice { Id = 15, Amount = 210.75m, PaymentDate = new DateTime(2025, 11, 18, 16, 10, 0), CustomerName = "Ethan Jones", CustomerEmail = "user5@example.com", FlightNumber = "DY1963" }
            );
        }
    }
}
