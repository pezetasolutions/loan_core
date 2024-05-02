using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class LoanStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Loans_LoanId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LoanId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Loans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "LoanStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_StatusId",
                table: "Loans",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LoanStatuses_StatusId",
                table: "Loans",
                column: "StatusId",
                principalTable: "LoanStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LoanStatuses_StatusId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "LoanStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_StatusId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Loans");

            migrationBuilder.AddColumn<Guid>(
                name: "LoanId",
                table: "Customers",
                type: "uuid",
                nullable: true);

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
    }
}
