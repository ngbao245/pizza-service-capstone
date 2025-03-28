using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class staffservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "WorkingDate",
                table: "WorkingSlotRegister",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "StaffName",
                table: "WorkingSlotRegister",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFromName",
                table: "SwapWorkingSlot",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeToName",
                table: "SwapWorkingSlot",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "WorkingDate",
                table: "StaffZoneSchedule",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "StaffName",
                table: "StaffZoneSchedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZoneName",
                table: "StaffZoneSchedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "ConfigType", "CreatedBy", "CreatedDate", "DeletedAt", "DeletedBy", "IsDeleted", "Key", "ModifiedBy", "ModifiedDate", "Value" },
                values: new object[,]
                {
                    { new Guid("984394dd-9af3-401f-9319-0c5a7a3686fd"), 3, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "REGISTRATION_WEEK_LIMIT", null, null, "2" },
                    { new Guid("b7c6da0c-f0de-44d7-9aa5-cb72eb569a9d"), 2, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "REGISTRATION_CUTOFF_DAY", null, null, "2" },
                    { new Guid("d2ee8501-1046-4895-bc33-cecbdb969f1b"), 4, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "SWAP_WORKING_SLOT_CUTOFF_DAY", null, null, "2" }
                });

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("1afe24bd-4d62-480b-a501-692bdd375bcb"),
                column: "Name",
                value: "Thứ năm");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("24a0e861-15b0-4d60-ac54-adf5ee0f1ccd"),
                column: "Name",
                value: "Thứ tư");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("478fcc2b-4839-4fc2-baff-db273aa9e0b4"),
                column: "Name",
                value: "Thứ hai");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("4c37288c-3a9c-4d6e-9565-4302a5a28669"),
                column: "Name",
                value: "Thứ bảy");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("93e1d6e5-b144-4099-be3c-833f7ef87fa3"),
                column: "Name",
                value: "Thứ sáu");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("c6f2594b-71f8-46ff-9584-c62c2e02151e"),
                column: "Name",
                value: "Chủ nhật");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("f8dec225-dbb2-4961-9be6-9f11eac723ab"),
                column: "Name",
                value: "Thứ ba");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("984394dd-9af3-401f-9319-0c5a7a3686fd"));

            migrationBuilder.DeleteData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("b7c6da0c-f0de-44d7-9aa5-cb72eb569a9d"));

            migrationBuilder.DeleteData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("d2ee8501-1046-4895-bc33-cecbdb969f1b"));

            migrationBuilder.DropColumn(
                name: "StaffName",
                table: "WorkingSlotRegister");

            migrationBuilder.DropColumn(
                name: "EmployeeFromName",
                table: "SwapWorkingSlot");

            migrationBuilder.DropColumn(
                name: "EmployeeToName",
                table: "SwapWorkingSlot");

            migrationBuilder.DropColumn(
                name: "StaffName",
                table: "StaffZoneSchedule");

            migrationBuilder.DropColumn(
                name: "ZoneName",
                table: "StaffZoneSchedule");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WorkingDate",
                table: "WorkingSlotRegister",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WorkingDate",
                table: "StaffZoneSchedule",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("1afe24bd-4d62-480b-a501-692bdd375bcb"),
                column: "Name",
                value: "Thursday");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("24a0e861-15b0-4d60-ac54-adf5ee0f1ccd"),
                column: "Name",
                value: "Wednesday");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("478fcc2b-4839-4fc2-baff-db273aa9e0b4"),
                column: "Name",
                value: "Monday");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("4c37288c-3a9c-4d6e-9565-4302a5a28669"),
                column: "Name",
                value: "Saturday");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("93e1d6e5-b144-4099-be3c-833f7ef87fa3"),
                column: "Name",
                value: "Friday");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("c6f2594b-71f8-46ff-9584-c62c2e02151e"),
                column: "Name",
                value: "Sunday");

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: new Guid("f8dec225-dbb2-4961-9be6-9f11eac723ab"),
                column: "Name",
                value: "Tuesday");
        }
    }
}
