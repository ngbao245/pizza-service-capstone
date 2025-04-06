using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatephonenumberv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRegister_Customer_CustomerId",
                table: "WorkshopRegister");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRegister_CustomerId",
                table: "WorkshopRegister");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "WorkshopRegister");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "WorkshopRegister",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "WorkshopRegister",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "WorkshopRegister");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "WorkshopRegister");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "WorkshopRegister",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRegister_CustomerId",
                table: "WorkshopRegister",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRegister_Customer_CustomerId",
                table: "WorkshopRegister",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
