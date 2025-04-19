using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatefieldreservationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentReservationId",
                table: "Table",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_CurrentReservationId",
                table: "Table",
                column: "CurrentReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Reservation_CurrentReservationId",
                table: "Table",
                column: "CurrentReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Reservation_CurrentReservationId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_CurrentReservationId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "CurrentReservationId",
                table: "Table");
        }
    }
}
