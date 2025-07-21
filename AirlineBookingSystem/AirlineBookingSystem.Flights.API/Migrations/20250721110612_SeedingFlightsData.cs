using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineBookingSystem.Flights.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingFlightsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AircraftType", "Arrival", "ArrivalAirportCode", "Departure", "DepartureAirportCode", "FlightCode", "Version" },
                values: new object[,]
                {
                    { 1, "Boeing 737-800", new DateTime(2025, 10, 12, 16, 45, 0, 0, DateTimeKind.Unspecified), "BUD", new DateTime(2025, 10, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), "OSL", "DY1550", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, "Airbus A320", new DateTime(2025, 10, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), "AMS", new DateTime(2025, 10, 13, 9, 15, 0, 0, DateTimeKind.Unspecified), "FRA", "LH2021", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, "Airbus A321", new DateTime(2025, 11, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), "MAD", new DateTime(2025, 11, 1, 17, 45, 0, 0, DateTimeKind.Unspecified), "CDG", "AF1133", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, "Boeing 777", new DateTime(2025, 11, 5, 9, 5, 0, 0, DateTimeKind.Unspecified), "ARN", new DateTime(2025, 11, 5, 6, 0, 0, 0, DateTimeKind.Unspecified), "LHR", "BA804", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, "Airbus A220", new DateTime(2025, 10, 20, 13, 40, 0, 0, DateTimeKind.Unspecified), "CPH", new DateTime(2025, 10, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), "OSL", "SK1502", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 6, "Embraer 190", new DateTime(2025, 11, 8, 12, 40, 0, 0, DateTimeKind.Unspecified), "MUC", new DateTime(2025, 11, 8, 10, 10, 0, 0, DateTimeKind.Unspecified), "HEL", "AY432", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, "Boeing 737 MAX 8", new DateTime(2025, 12, 3, 0, 30, 0, 0, DateTimeKind.Unspecified), "FCO", new DateTime(2025, 12, 2, 21, 45, 0, 0, DateTimeKind.Unspecified), "IST", "TK1891", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 8, "Embraer 175", new DateTime(2025, 10, 27, 15, 10, 0, 0, DateTimeKind.Unspecified), "OSL", new DateTime(2025, 10, 27, 13, 20, 0, 0, DateTimeKind.Unspecified), "AMS", "KLM1187", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 9, "Airbus A321neo", new DateTime(2025, 11, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "LTN", new DateTime(2025, 11, 3, 7, 10, 0, 0, DateTimeKind.Unspecified), "BUD", "W61302", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 10, "Boeing 737-800", new DateTime(2025, 11, 10, 20, 10, 0, 0, DateTimeKind.Unspecified), "ZRH", new DateTime(2025, 11, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), "WAW", "LO285", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 11, "Airbus A320", new DateTime(2025, 10, 30, 17, 10, 0, 0, DateTimeKind.Unspecified), "LIS", new DateTime(2025, 10, 30, 15, 50, 0, 0, DateTimeKind.Unspecified), "BCN", "IB3517", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 12, "Airbus A319", new DateTime(2025, 12, 13, 0, 55, 0, 0, DateTimeKind.Unspecified), "ATH", new DateTime(2025, 12, 12, 22, 15, 0, 0, DateTimeKind.Unspecified), "FCO", "AZ6051", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 13, "Bombardier CS300", new DateTime(2025, 11, 14, 10, 25, 0, 0, DateTimeKind.Unspecified), "VIE", new DateTime(2025, 11, 14, 8, 40, 0, 0, DateTimeKind.Unspecified), "ZRH", "LX1624", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 14, "Airbus A320neo", new DateTime(2025, 10, 31, 8, 10, 0, 0, DateTimeKind.Unspecified), "FRA", new DateTime(2025, 10, 31, 5, 55, 0, 0, DateTimeKind.Unspecified), "LGW", "EZY4283", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 15, "Boeing 737-800", new DateTime(2025, 11, 18, 18, 40, 0, 0, DateTimeKind.Unspecified), "CDG", new DateTime(2025, 11, 18, 16, 10, 0, 0, DateTimeKind.Unspecified), "OSL", "DY1963", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
