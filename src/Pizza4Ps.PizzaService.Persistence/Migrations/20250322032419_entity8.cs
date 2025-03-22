using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entity8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "ConfigType", "CreatedBy", "CreatedDate", "DeletedAt", "DeletedBy", "IsDeleted", "Key", "ModifiedBy", "ModifiedDate", "Value" },
                values: new object[,]
                {
                    { new Guid("738eda23-9323-4db9-b36b-73adb8e942ef"), 0, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Thuế VAT", null, null, "0.08" },
                    { new Guid("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"), 1, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Thuế VAT", null, null, "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("738eda23-9323-4db9-b36b-73adb8e942ef"));

            migrationBuilder.DeleteData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("e0d7298b-5cd8-47e4-939c-e42e4e5a42e5"));
        }
    }
}
