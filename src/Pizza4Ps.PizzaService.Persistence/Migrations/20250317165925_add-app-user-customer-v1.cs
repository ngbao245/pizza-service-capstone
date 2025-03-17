using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addappusercustomerv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AppUserCustomer");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AppUserCustomer");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "AppUserCustomer");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AppUserCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AppUserCustomer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AppUserCustomer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AppUserCustomer",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AppUserCustomer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AppUserCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AppUserCustomer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
