using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class TransactionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("c3014ed4-d4b3-4bc4-84be-298e646f22c7"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e54a6a08-2e5d-417f-bc93-64a07075b8e3"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("f971ace4-6caa-4f6b-bd22-e3098d341d92"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("266035e5-dd47-4297-a322-4ca9b2344c04"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b555ef14-3e28-4e96-aae6-737ce7ee6e77"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("f2032fdb-3654-46b3-bcfe-58efa451caea"));

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "Loans",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "LoanStatuses",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("991dd282-e17d-497a-9383-54d809bd29e1"), new DateTime(2024, 5, 3, 5, 10, 1, 408, DateTimeKind.Utc).AddTicks(8186), "Préstamo activo con mensualidad atrasada", "Late" },
                    { new Guid("bb80b7e2-c2de-4907-a820-f1d67a46b1c3"), new DateTime(2024, 5, 3, 5, 10, 1, 408, DateTimeKind.Utc).AddTicks(8182), "Préstamo activo", "Active" },
                    { new Guid("ebd9e503-a577-495f-b3f5-b9fe0cff5e0f"), new DateTime(2024, 5, 3, 5, 10, 1, 408, DateTimeKind.Utc).AddTicks(8184), "Préstamo liquidado", "Paid" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("10bd1349-0dcc-4b2e-9144-e040d683c64b"), "Liquidación total del préstamo", "Payment" },
                    { new Guid("47007562-e377-4744-b3e6-01dd806f6c30"), "Pago del interés generado por el préstamo", "Interest" },
                    { new Guid("864c304b-740d-45e9-af86-acb66771278d"), "Abono al capital", "PartialPay" },
                    { new Guid("b137d530-408c-4ac5-96b1-28ae1a7e7f09"), "Descuento al interés del préstamo", "Discount" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("991dd282-e17d-497a-9383-54d809bd29e1"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("bb80b7e2-c2de-4907-a820-f1d67a46b1c3"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("ebd9e503-a577-495f-b3f5-b9fe0cff5e0f"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("10bd1349-0dcc-4b2e-9144-e040d683c64b"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("47007562-e377-4744-b3e6-01dd806f6c30"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("864c304b-740d-45e9-af86-acb66771278d"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b137d530-408c-4ac5-96b1-28ae1a7e7f09"));

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Loans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.InsertData(
                table: "LoanStatuses",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("c3014ed4-d4b3-4bc4-84be-298e646f22c7"), new DateTime(2024, 5, 3, 3, 32, 10, 676, DateTimeKind.Utc).AddTicks(8404), "Préstamo activo", "Active" },
                    { new Guid("e54a6a08-2e5d-417f-bc93-64a07075b8e3"), new DateTime(2024, 5, 3, 3, 32, 10, 676, DateTimeKind.Utc).AddTicks(8415), "Préstamo liquidado", "Paid" },
                    { new Guid("f971ace4-6caa-4f6b-bd22-e3098d341d92"), new DateTime(2024, 5, 3, 3, 32, 10, 676, DateTimeKind.Utc).AddTicks(8416), "Préstamo activo con mensualidad atrasada", "Late" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("266035e5-dd47-4297-a322-4ca9b2344c04"), "Pago del interés generado por el préstamo", "Interest" },
                    { new Guid("b555ef14-3e28-4e96-aae6-737ce7ee6e77"), "Liquidación total del préstamo", "Payment" },
                    { new Guid("f2032fdb-3654-46b3-bcfe-58efa451caea"), "Descuento al interés del préstamo", "Discount" }
                });
        }
    }
}
