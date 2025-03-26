using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addfieldstaffservic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "StaffZoneSchedule",
                newName: "WorkingDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingDate",
                table: "WorkingSlotRegister",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DayName",
                table: "WorkingSlot",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShiftName",
                table: "WorkingSlot",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingDate",
                table: "WorkingSlotRegister");

            migrationBuilder.DropColumn(
                name: "DayName",
                table: "WorkingSlot");

            migrationBuilder.DropColumn(
                name: "ShiftName",
                table: "WorkingSlot");

            migrationBuilder.RenameColumn(
                name: "WorkingDate",
                table: "StaffZoneSchedule",
                newName: "Date");
        }
    }
}
