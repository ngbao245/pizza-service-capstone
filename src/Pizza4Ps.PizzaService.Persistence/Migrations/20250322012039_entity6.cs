using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entity6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayofWeek",
                table: "StaffZoneSchedule");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "StaffZoneSchedule");

            migrationBuilder.DropColumn(
                name: "ShiftEnd",
                table: "StaffZoneSchedule");

            migrationBuilder.DropColumn(
                name: "ShiftStart",
                table: "StaffZoneSchedule");

            migrationBuilder.RenameColumn(
                name: "WorkingTimeId",
                table: "StaffZoneSchedule",
                newName: "WorkingSlotId");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "StaffZone",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "WorkingSlot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    ShiftEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingSlot_Day_DayId",
                        column: x => x.DayId,
                        principalTable: "Day",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSlot_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSlotRegister",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingSlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSlotRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingSlotRegister_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSlotRegister_WorkingSlot_WorkingSlotId",
                        column: x => x.WorkingSlotId,
                        principalTable: "WorkingSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffZoneSchedule_WorkingSlotId",
                table: "StaffZoneSchedule",
                column: "WorkingSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlot_DayId",
                table: "WorkingSlot",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlot_ShiftId",
                table: "WorkingSlot",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlotRegister_StaffId",
                table: "WorkingSlotRegister",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlotRegister_WorkingSlotId",
                table: "WorkingSlotRegister",
                column: "WorkingSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffZoneSchedule_WorkingSlot_WorkingSlotId",
                table: "StaffZoneSchedule",
                column: "WorkingSlotId",
                principalTable: "WorkingSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffZoneSchedule_WorkingSlot_WorkingSlotId",
                table: "StaffZoneSchedule");

            migrationBuilder.DropTable(
                name: "WorkingSlotRegister");

            migrationBuilder.DropTable(
                name: "WorkingSlot");

            migrationBuilder.DropIndex(
                name: "IX_StaffZoneSchedule_WorkingSlotId",
                table: "StaffZoneSchedule");

            migrationBuilder.RenameColumn(
                name: "WorkingSlotId",
                table: "StaffZoneSchedule",
                newName: "WorkingTimeId");

            migrationBuilder.AddColumn<int>(
                name: "DayofWeek",
                table: "StaffZoneSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "StaffZoneSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "ShiftEnd",
                table: "StaffZoneSchedule",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "ShiftStart",
                table: "StaffZoneSchedule",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "StaffZone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
