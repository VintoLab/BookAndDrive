using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndDrive.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExtrasOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtraTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ExtraTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderExtras_ExtraTypes_ExtraTypeId",
                        column: x => x.ExtraTypeId,
                        principalTable: "ExtraTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderExtras_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderExtras_ExtraTypeId",
                table: "OrderExtras",
                column: "ExtraTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderExtras_OrderId",
                table: "OrderExtras",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderExtras");

            migrationBuilder.DropTable(
                name: "ExtraTypes");
        }
    }
}
