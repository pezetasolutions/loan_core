using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Transactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LoanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LoanId",
                table: "Transactions",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TypeId",
                table: "Transactions",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

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
    }
}
