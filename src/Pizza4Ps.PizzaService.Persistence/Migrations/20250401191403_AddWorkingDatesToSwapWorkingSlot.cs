using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkingDatesToSwapWorkingSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "WorkingDateFrom",
                table: "SwapWorkingSlot",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "WorkingDateTo",
                table: "SwapWorkingSlot",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsHandled",
                table: "Notification",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Payload",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "RequiresPersistence",
                table: "Notification",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingDateFrom",
                table: "SwapWorkingSlot");

            migrationBuilder.DropColumn(
                name: "WorkingDateTo",
                table: "SwapWorkingSlot");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "IsHandled",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Payload",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "RequiresPersistence",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notification");
        }
    }
}
