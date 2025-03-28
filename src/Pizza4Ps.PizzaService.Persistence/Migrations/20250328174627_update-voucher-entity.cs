using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatevoucherentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_VoucherType_VoucherTypeId",
                table: "Voucher");

            migrationBuilder.DropTable(
                name: "VoucherType");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_VoucherTypeId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "VoucherTypeId",
                table: "Voucher");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClaimedAt",
                table: "Voucher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClaimedByCustomerId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                table: "Voucher",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsClaimed",
                table: "Voucher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherBatchId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VoucherBatch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    RemainingQuantity = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_VoucherBatch", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VoucherBatchId",
                table: "Voucher",
                column: "VoucherBatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_VoucherBatch_VoucherBatchId",
                table: "Voucher",
                column: "VoucherBatchId",
                principalTable: "VoucherBatch",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_VoucherBatch_VoucherBatchId",
                table: "Voucher");

            migrationBuilder.DropTable(
                name: "VoucherBatch");

            migrationBuilder.DropIndex(
                name: "IX_Voucher_VoucherBatchId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ClaimedAt",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "ClaimedByCustomerId",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "IsClaimed",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "VoucherBatchId",
                table: "Voucher");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Voucher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherTypeId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VoucherType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VoucherTypeId",
                table: "Voucher",
                column: "VoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_VoucherType_VoucherTypeId",
                table: "Voucher",
                column: "VoucherTypeId",
                principalTable: "VoucherType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
