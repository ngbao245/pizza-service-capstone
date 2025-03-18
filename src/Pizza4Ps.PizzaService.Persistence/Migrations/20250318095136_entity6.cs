using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entity6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AdditionalFee_AdditionalFeeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AdditionalFeeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AdditionalFeeId",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "AdditionalFee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFee_OrderId",
                table: "AdditionalFee",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFee_Order_OrderId",
                table: "AdditionalFee",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFee_Order_OrderId",
                table: "AdditionalFee");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFee_OrderId",
                table: "AdditionalFee");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "AdditionalFee");

            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalFeeId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_AdditionalFeeId",
                table: "Order",
                column: "AdditionalFeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AdditionalFee_AdditionalFeeId",
                table: "Order",
                column: "AdditionalFeeId",
                principalTable: "AdditionalFee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
