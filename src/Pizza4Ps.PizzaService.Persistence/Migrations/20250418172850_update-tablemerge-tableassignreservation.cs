using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza4Ps.PizzaService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatetablemergetableassignreservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TableMergeId",
                table: "Table",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableMergeName",
                table: "Table",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TableAssignReservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_TableAssignReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableAssignReservation_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TableAssignReservation_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TableMerge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_TableMerge", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "ConfigType", "CreatedBy", "CreatedDate", "DeletedAt", "DeletedBy", "IsDeleted", "Key", "ModifiedBy", "ModifiedDate", "Unit", "Value" },
                values: new object[] { new Guid("738eda23-9323-4db9-b36b-75adb8e942ef"), 6, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, "Giới hạn thời gian tối đa được phép sắp xếp bàn trước so với thời điểm hiện tại", null, null, "Phút", "45" });

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableMergeId",
                table: "Table",
                column: "TableMergeId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssignReservation_ReservationId",
                table: "TableAssignReservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAssignReservation_TableId",
                table: "TableAssignReservation",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_TableMerge_TableMergeId",
                table: "Table",
                column: "TableMergeId",
                principalTable: "TableMerge",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_TableMerge_TableMergeId",
                table: "Table");

            migrationBuilder.DropTable(
                name: "TableAssignReservation");

            migrationBuilder.DropTable(
                name: "TableMerge");

            migrationBuilder.DropIndex(
                name: "IX_Table_TableMergeId",
                table: "Table");

            migrationBuilder.DeleteData(
                table: "Config",
                keyColumn: "Id",
                keyValue: new Guid("738eda23-9323-4db9-b36b-75adb8e942ef"));

            migrationBuilder.DropColumn(
                name: "TableMergeId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "TableMergeName",
                table: "Table");
        }
    }
}
