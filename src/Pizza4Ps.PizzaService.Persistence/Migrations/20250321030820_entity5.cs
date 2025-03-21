using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entity5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Staff_Code",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Staff",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Staff",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Staff",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Code",
                table: "Staff",
                column: "Code",
                unique: true);
        }
    }
}
