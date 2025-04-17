using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateorderfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Table",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Order");
        }
    }
}
