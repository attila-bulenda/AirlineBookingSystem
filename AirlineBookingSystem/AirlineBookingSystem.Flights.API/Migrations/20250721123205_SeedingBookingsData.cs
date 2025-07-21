using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineBookingSystem.Flights.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingBookingsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "FlightId", "PassengerName", "PassportNumber", "SeatNumber", "Version" },
                values: new object[,]
                {
                    { 1, 1, "John Smith", "BX534916732", "12C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, 3, "Alice Thompson", "AX128374950", "14A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, 5, "Liam Johnson", "CT938471205", "22F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, 1, "Emma Wilson", "PL372849172", "8B", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, 7, "Noah Brown", "YX182736459", "16C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 6, 2, "Olivia Davis", "RB273648159", "10A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, 4, "James Taylor", "QP394857612", "9E", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 8, 6, "Sophia Martinez", "KM837261945", "19D", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 9, 9, "Benjamin Lee", "UT928374560", "13B", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 10, 10, "Isabella White", "DZ173849260", "21A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 11, 2, "Lucas Harris", "WL294837165", "12D", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 12, 8, "Mia Clark", "GX193847205", "23C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 13, 5, "Henry Young", "JF384726195", "7F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 14, 3, "Charlotte Allen", "MB837261934", "15E", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 15, 11, "Alexander Scott", "ER918374612", "18B", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 16, 14, "Amelia King", "PK183746205", "5C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 17, 6, "Daniel Green", "ZH827364920", "6D", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 18, 12, "Evelyn Hall", "NL728394651", "17A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 19, 13, "Matthew Baker", "LS283746159", "24F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 20, 10, "Harper Nelson", "CV837465120", "20E", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 21, 4, "Jackson Adams", "HT918374621", "3A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 22, 7, "Abigail Rivera", "UV837162930", "4B", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 23, 9, "Sebastian Ramirez", "YX847261950", "2F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 24, 8, "Emily Perez", "KG837261940", "11C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 25, 1, "Aiden Carter", "NE102938475", "6E", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 26, 13, "Ella Roberts", "RH837261953", "1D", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 27, 12, "Logan Mitchell", "FE918374625", "7C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 28, 15, "Scarlett Turner", "OB374829105", "8F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 29, 6, "David Phillips", "MT837261970", "5A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 30, 11, "Grace Campbell", "EQ193847205", "9B", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 31, 14, "Joseph Parker", "RE827364920", "10F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 32, 5, "Chloe Evans", "SU837261984", "13A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 33, 2, "Samuel Edwards", "TK273849162", "17F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 34, 3, "Aria Collins", "VC837261918", "18C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 35, 15, "Elijah Stewart", "BG837261933", "14E", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 36, 7, "Victoria Sanchez", "ZH837261911", "22C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 37, 9, "Wyatt Morris", "DE283746195", "19B", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 38, 6, "Zoey Rogers", "XM837261997", "15A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 39, 8, "Gabriel Reed", "PY837261934", "16F", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 40, 10, "Lily Cook", "TR827364928", "12B", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 40);
        }
    }
}
