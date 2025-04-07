using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateorderv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinalPrice",
                table: "Order",
                newName: "TotalOrderItemPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAdditionalFeePrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAdditionalFeePrice",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "TotalOrderItemPrice",
                table: "Order",
                newName: "FinalPrice");
        }
    }
}
