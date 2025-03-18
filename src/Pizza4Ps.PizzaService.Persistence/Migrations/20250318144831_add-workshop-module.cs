using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addworkshopmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workshop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotLineContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxRegister = table.Column<int>(type: "int", nullable: false),
                    MaxPizzaPerRegister = table.Column<int>(type: "int", nullable: false),
                    MaxParticipantPerRegister = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopFoodDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkshopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopFoodDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopFoodDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopFoodDetail_Workshop_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopRegister",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkshopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkshopRegisterStatus = table.Column<int>(type: "int", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalParticipant = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopRegister_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopRegister_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkshopRegister_Workshop_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopPizzaRegister",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkshopRegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopPizzaRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopPizzaRegister_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopPizzaRegister_WorkshopRegister_WorkshopRegisterId",
                        column: x => x.WorkshopRegisterId,
                        principalTable: "WorkshopRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopPizzaRegisterDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkshopPizzaRegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OptionItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopPizzaRegisterDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopPizzaRegisterDetail_OptionItem_OptionItemId",
                        column: x => x.OptionItemId,
                        principalTable: "OptionItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopPizzaRegisterDetail_WorkshopPizzaRegister_WorkshopPizzaRegisterId",
                        column: x => x.WorkshopPizzaRegisterId,
                        principalTable: "WorkshopPizzaRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopFoodDetail_ProductId",
                table: "WorkshopFoodDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopFoodDetail_WorkshopId",
                table: "WorkshopFoodDetail",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopPizzaRegister_ProductId",
                table: "WorkshopPizzaRegister",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopPizzaRegister_WorkshopRegisterId",
                table: "WorkshopPizzaRegister",
                column: "WorkshopRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopPizzaRegisterDetail_OptionItemId",
                table: "WorkshopPizzaRegisterDetail",
                column: "OptionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopPizzaRegisterDetail_WorkshopPizzaRegisterId",
                table: "WorkshopPizzaRegisterDetail",
                column: "WorkshopPizzaRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRegister_CustomerId",
                table: "WorkshopRegister",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRegister_OrderId",
                table: "WorkshopRegister",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRegister_WorkshopId",
                table: "WorkshopRegister",
                column: "WorkshopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopFoodDetail");

            migrationBuilder.DropTable(
                name: "WorkshopPizzaRegisterDetail");

            migrationBuilder.DropTable(
                name: "WorkshopPizzaRegister");

            migrationBuilder.DropTable(
                name: "WorkshopRegister");

            migrationBuilder.DropTable(
                name: "Workshop");
        }
    }
}
