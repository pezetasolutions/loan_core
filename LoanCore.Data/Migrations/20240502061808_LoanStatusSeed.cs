using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class LoanStatusSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LoanStatuses",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3f008e1f-43a4-4127-a875-37d28e7f225b"), new DateTime(2024, 5, 2, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(1497), "Préstamo activo con mensualidad atrasada", "Late" },
                    { new Guid("5ca85223-78d3-40c9-9918-28257b551aab"), new DateTime(2024, 5, 2, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(1496), "Préstamo liquidado", "Paid" },
                    { new Guid("da02b6da-b09e-4deb-b9b6-e290a4ea7326"), new DateTime(2024, 5, 2, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(1494), "Préstamo activo", "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("3f008e1f-43a4-4127-a875-37d28e7f225b"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("5ca85223-78d3-40c9-9918-28257b551aab"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("da02b6da-b09e-4deb-b9b6-e290a4ea7326"));
        }
    }
}
