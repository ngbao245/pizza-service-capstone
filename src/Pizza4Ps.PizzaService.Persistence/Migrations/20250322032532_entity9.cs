using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entity9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("738eda23-9323-4db9-b36b-73adb8e942ef"),
                column: "Key",
                value: "VAT");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"),
                column: "Key",
                value: "MAXIMUM_REGISTER_SLOT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("738eda23-9323-4db9-b36b-73adb8e942ef"),
                column: "Key",
                value: "Thuế VAT");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"),
                column: "Key",
                value: "Thuế VAT");
        }
    }
}
