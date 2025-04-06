using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffZone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftEnd",
                table: "StaffZone");

            migrationBuilder.DropColumn(
                name: "ShiftStart",
                table: "StaffZone");

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "ConfigType", "CreatedBy", "CreatedDate", "DeletedAt", "DeletedBy", "IsDeleted", "Key", "ModifiedBy", "ModifiedDate", "Value" },
                values: new object[] { new Guid("37c23088-09b3-4f3d-8d56-e1183a899cca"), 5, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "MAXIMUM_REGISTER_PER_STAFF", null, null, "3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("37c23088-09b3-4f3d-8d56-e1183a899cca"));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "ShiftEnd",
                table: "StaffZone",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "ShiftStart",
                table: "StaffZone",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
