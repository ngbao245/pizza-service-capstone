using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addworkshopmodulev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ZoneId",
                table: "Workshop",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ZoneName",
                table: "Workshop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Workshop_ZoneId",
                table: "Workshop",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshop_Zone_ZoneId",
                table: "Workshop",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshop_Zone_ZoneId",
                table: "Workshop");

            migrationBuilder.DropIndex(
                name: "IX_Workshop_ZoneId",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "ZoneName",
                table: "Workshop");
        }
    }
}
