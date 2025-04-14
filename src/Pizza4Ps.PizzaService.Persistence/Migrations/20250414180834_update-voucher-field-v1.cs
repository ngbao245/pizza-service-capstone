using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatevoucherfieldv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePoint",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ClaimedAt",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ClaimedByCustomerId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "IsClaimed",
                table: "Voucher");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ChangePoint",
                table: "Voucher",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClaimedAt",
                table: "Voucher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClaimedByCustomerId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClaimed",
                table: "Voucher",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
