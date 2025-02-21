using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixnameorderitemdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionItemOrderItem_OptionItem_OptionItemId",
                table: "OptionItemOrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionItemOrderItem_OrderItem_OrderItemId",
                table: "OptionItemOrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionItemOrderItem",
                table: "OptionItemOrderItem");

            migrationBuilder.RenameTable(
                name: "OptionItemOrderItem",
                newName: "OrderItemDetail");

            migrationBuilder.RenameIndex(
                name: "IX_OptionItemOrderItem_OrderItemId",
                table: "OrderItemDetail",
                newName: "IX_OrderItemDetail_OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OptionItemOrderItem_OptionItemId",
                table: "OrderItemDetail",
                newName: "IX_OrderItemDetail_OptionItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemDetail",
                table: "OrderItemDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemDetail_OptionItem_OptionItemId",
                table: "OrderItemDetail",
                column: "OptionItemId",
                principalTable: "OptionItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemDetail_OrderItem_OrderItemId",
                table: "OrderItemDetail",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemDetail_OptionItem_OptionItemId",
                table: "OrderItemDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemDetail_OrderItem_OrderItemId",
                table: "OrderItemDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemDetail",
                table: "OrderItemDetail");

            migrationBuilder.RenameTable(
                name: "OrderItemDetail",
                newName: "OptionItemOrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemDetail_OrderItemId",
                table: "OptionItemOrderItem",
                newName: "IX_OptionItemOrderItem_OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemDetail_OptionItemId",
                table: "OptionItemOrderItem",
                newName: "IX_OptionItemOrderItem_OptionItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionItemOrderItem",
                table: "OptionItemOrderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionItemOrderItem_OptionItem_OptionItemId",
                table: "OptionItemOrderItem",
                column: "OptionItemId",
                principalTable: "OptionItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionItemOrderItem_OrderItem_OrderItemId",
                table: "OptionItemOrderItem",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
