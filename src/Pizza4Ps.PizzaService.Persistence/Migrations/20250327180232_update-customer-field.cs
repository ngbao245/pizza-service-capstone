using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatecustomerfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                table: "Reservation",
                newName: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customer_CustomerId",
                table: "Reservation",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customer_CustomerId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservation",
                newName: "CustomerCode");
        }
    }
}
