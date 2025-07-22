using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineBookingSystem.Flights.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlightCode = table.Column<string>(type: "TEXT", nullable: false),
                    Departure = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Arrival = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartureAirportCode = table.Column<string>(type: "TEXT", nullable: false),
                    ArrivalAirportCode = table.Column<string>(type: "TEXT", nullable: false),
                    AircraftType = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassengerName = table.Column<string>(type: "TEXT", nullable: false),
                    PassportNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SeatNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
