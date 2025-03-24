using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateworkshopregisterfieldv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRegister_Order_OrderId",
                table: "WorkshopRegister");

            migrationBuilder.AddColumn<string>(
                name: "TableCode",
                table: "WorkshopRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TableId",
                table: "WorkshopRegister",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRegister_TableId",
                table: "WorkshopRegister",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRegister_Order_OrderId",
                table: "WorkshopRegister",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRegister_Table_TableId",
                table: "WorkshopRegister",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRegister_Order_OrderId",
                table: "WorkshopRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopRegister_Table_TableId",
                table: "WorkshopRegister");

            migrationBuilder.DropIndex(
                name: "IX_WorkshopRegister_TableId",
                table: "WorkshopRegister");

            migrationBuilder.DropColumn(
                name: "TableCode",
                table: "WorkshopRegister");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "WorkshopRegister");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopRegister_Order_OrderId",
                table: "WorkshopRegister",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
