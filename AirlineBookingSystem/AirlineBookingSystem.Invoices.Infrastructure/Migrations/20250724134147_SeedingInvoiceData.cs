using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineBookingSystem.Invoices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingInvoiceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "CustomerEmail", "CustomerName", "FlightNumber", "PaymentDate" },
                values: new object[,]
                {
                    { 1, 199.99m, "user1@example.com", "Alice Smith", "DY1550", new DateTime(2025, 10, 12, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 149.50m, "user2@example.com", "Bob Johnson", "LH2021", new DateTime(2025, 10, 13, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 275.20m, "user3@example.com", "Charlie Williams", "AF1133", new DateTime(2025, 11, 1, 17, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 189.00m, "user4@example.com", "Diana Brown", "BA804", new DateTime(2025, 11, 5, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 129.45m, "user5@example.com", "Ethan Jones", "SK1502", new DateTime(2025, 10, 20, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 215.80m, "user6@example.com", "Fiona Garcia", "AY432", new DateTime(2025, 11, 8, 10, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 305.00m, "user7@example.com", "George Martinez", "TK1891", new DateTime(2025, 12, 2, 21, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 170.10m, "user8@example.com", "Hannah Davis", "KLM1187", new DateTime(2025, 10, 27, 13, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 112.75m, "user9@example.com", "Ian Rodriguez", "W61302", new DateTime(2025, 11, 3, 7, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 225.30m, "user10@example.com", "Julia Lopez", "LO285", new DateTime(2025, 11, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 160.00m, "user1@example.com", "Alice Smith", "IB3517", new DateTime(2025, 10, 30, 15, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 198.88m, "user2@example.com", "Bob Johnson", "AZ6051", new DateTime(2025, 12, 12, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 142.60m, "user3@example.com", "Charlie Williams", "LX1624", new DateTime(2025, 11, 14, 8, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 134.00m, "user4@example.com", "Diana Brown", "EZY4283", new DateTime(2025, 10, 31, 5, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 210.75m, "user5@example.com", "Ethan Jones", "DY1963", new DateTime(2025, 11, 18, 16, 10, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
