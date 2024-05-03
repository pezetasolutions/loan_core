using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class LoanNewStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "LoanStatuses",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0ee833d0-4ec8-4804-8bc1-55fd37312933"), new DateTime(2024, 5, 3, 21, 2, 38, 641, DateTimeKind.Utc).AddTicks(244), "Préstamo liquidado", "Paid" },
                    { new Guid("5c94273a-2811-42a7-b766-4895b71d6ee6"), new DateTime(2024, 5, 3, 21, 2, 38, 641, DateTimeKind.Utc).AddTicks(240), "Préstamo activo", "Active" },
                    { new Guid("aef261a4-1e4a-41a8-84af-7ccf2baafe1f"), new DateTime(2024, 5, 3, 21, 2, 38, 641, DateTimeKind.Utc).AddTicks(246), "Préstamo activo con mensualidad atrasada", "Late" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("081497aa-95c9-4ae6-a6fe-645310396f34"), "Pago del interés generado por el préstamo", "Interest" },
                    { new Guid("581abd47-fa1a-4040-acc4-936de4aecde7"), "Descuento al interés del préstamo", "Discount" },
                    { new Guid("7a121aa4-a054-4217-938e-5855a429063a"), "Liquidación total del préstamo", "Payment" },
                    { new Guid("9888c9c4-b41d-4e62-8773-753c397c8c77"), "Abono al capital", "PartialPay" },
                    { new Guid("d83ad69b-dfe6-4291-9433-8c517311d734"), "Pago del interés correspondiente para cambiar fecha de pago", "InterestToChangeDay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("0ee833d0-4ec8-4804-8bc1-55fd37312933"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("5c94273a-2811-42a7-b766-4895b71d6ee6"));

            migrationBuilder.DeleteData(
                table: "LoanStatuses",
                keyColumn: "Id",
                keyValue: new Guid("aef261a4-1e4a-41a8-84af-7ccf2baafe1f"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("081497aa-95c9-4ae6-a6fe-645310396f34"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("581abd47-fa1a-4040-acc4-936de4aecde7"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a121aa4-a054-4217-938e-5855a429063a"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("9888c9c4-b41d-4e62-8773-753c397c8c77"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("d83ad69b-dfe6-4291-9433-8c517311d734"));

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
    }
}
