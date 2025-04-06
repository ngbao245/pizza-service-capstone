using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateconfigv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "OrderItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonCancel",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTimeCooking",
                table: "OrderItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTimeServing",
                table: "OrderItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("37c23088-09b3-4f3d-8d56-e1183a899cca"),
                column: "Unit",
                value: "Ca làm việc");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("738eda23-9323-4db9-b36b-73adb8e942ef"),
                columns: new[] { "Unit", "Value" },
                values: new object[] { "%", "80" });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("984394dd-9af3-401f-9319-0c5a7a3686fd"),
                column: "Unit",
                value: "Tuần");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("b7c6da0c-f0de-44d7-9aa5-cb72eb569a9d"),
                column: "Unit",
                value: "Ngày");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("d2ee8501-1046-4895-bc33-cecbdb969f1b"),
                column: "Unit",
                value: "Ngày");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"),
                column: "Unit",
                value: "Nhân viên");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ReasonCancel",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "StartTimeCooking",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "StartTimeServing",
                table: "OrderItem");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "OrderItem",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("37c23088-09b3-4f3d-8d56-e1183a899cca"),
                column: "Unit",
                value: null);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("738eda23-9323-4db9-b36b-73adb8e942ef"),
                columns: new[] { "Unit", "Value" },
                values: new object[] { null, "0.08" });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("984394dd-9af3-401f-9319-0c5a7a3686fd"),
                column: "Unit",
                value: null);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("b7c6da0c-f0de-44d7-9aa5-cb72eb569a9d"),
                column: "Unit",
                value: null);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("d2ee8501-1046-4895-bc33-cecbdb969f1b"),
                column: "Unit",
                value: null);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"),
                column: "Unit",
                value: null);
        }
    }
}
