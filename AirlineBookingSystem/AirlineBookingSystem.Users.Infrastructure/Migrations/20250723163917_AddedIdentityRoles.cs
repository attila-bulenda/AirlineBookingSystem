using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineBookingSystem.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18725878-b05c-4f96-bfbb-28182ed38ce9", null, "User", "USER" },
                    { "567960c7-64bb-4ca3-ad90-15f5fa009d3c", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18725878-b05c-4f96-bfbb-28182ed38ce9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "567960c7-64bb-4ca3-ad90-15f5fa009d3c");
        }
    }
}
