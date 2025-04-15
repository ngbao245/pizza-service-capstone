using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatefieldvoucherv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Voucher");

            migrationBuilder.AddColumn<int>(
                name: "VoucherStatus",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherStatus",
                table: "Voucher");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Voucher",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
