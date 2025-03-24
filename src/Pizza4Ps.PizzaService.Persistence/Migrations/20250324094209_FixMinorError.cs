using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixMinorError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId1",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_IngredientId1",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "IngredientId1",
                table: "Recipe");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductSize",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductId1",
                table: "ProductSize",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Product_ProductId1",
                table: "ProductSize",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Product_ProductId1",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_ProductId1",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductSize");

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientId1",
                table: "Recipe",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IngredientId1",
                table: "Recipe",
                column: "IngredientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId1",
                table: "Recipe",
                column: "IngredientId1",
                principalTable: "Ingredient",
                principalColumn: "Id");
        }
    }
}
