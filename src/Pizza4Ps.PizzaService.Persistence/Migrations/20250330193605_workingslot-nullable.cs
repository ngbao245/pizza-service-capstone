using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class workingslotnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffZoneSchedule_WorkingSlot_WorkingSlotId",
                table: "StaffZoneSchedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkingSlotId",
                table: "StaffZoneSchedule",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffZoneSchedule_WorkingSlot_WorkingSlotId",
                table: "StaffZoneSchedule",
                column: "WorkingSlotId",
                principalTable: "WorkingSlot",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffZoneSchedule_WorkingSlot_WorkingSlotId",
                table: "StaffZoneSchedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkingSlotId",
                table: "StaffZoneSchedule",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffZoneSchedule_WorkingSlot_WorkingSlotId",
                table: "StaffZoneSchedule",
                column: "WorkingSlotId",
                principalTable: "WorkingSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
