using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateproductfieldv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_ProductSize_ProductSizeId",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ProductSizeId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "Recipe");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Recipe",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ProductId",
                table: "Recipe",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Product_ProductId",
                table: "Recipe",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Product_ProductId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ProductId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Recipe");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductSizeId",
                table: "Recipe",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diameter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSize_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ProductSizeId",
                table: "Recipe",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductId",
                table: "ProductSize",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_ProductSize_ProductSizeId",
                table: "Recipe",
                column: "ProductSizeId",
                principalTable: "ProductSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
