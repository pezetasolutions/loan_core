using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Loans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LoanId",
                table: "Customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false),
                    MonthlyInterest = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LoanId",
                table: "Customers",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Loans_LoanId",
                table: "Customers",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Loans_LoanId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LoanId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Customers");
        }
    }
}
