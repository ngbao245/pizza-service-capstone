using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffZoneSchedule_WorkingTime_WorkingTimeId",
                table: "StaffZoneSchedule");

            migrationBuilder.DropTable(
                name: "WorkingTime");

            migrationBuilder.DropIndex(
                name: "IX_StaffZoneSchedule_WorkingTimeId",
                table: "StaffZoneSchedule");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Zone");

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherTypeId",
                table: "Vouchers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherTypeId",
                table: "Vouchers");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Zone",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkingTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShiftCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTime", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffZoneSchedule_WorkingTimeId",
                table: "StaffZoneSchedule",
                column: "WorkingTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffZoneSchedule_WorkingTime_WorkingTimeId",
                table: "StaffZoneSchedule",
                column: "WorkingTimeId",
                principalTable: "WorkingTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
