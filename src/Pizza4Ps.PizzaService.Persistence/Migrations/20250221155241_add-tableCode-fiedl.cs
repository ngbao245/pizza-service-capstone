using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtableCodefiedl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Table");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TableCode",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TableCode",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "TableCode",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "TableCode",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
