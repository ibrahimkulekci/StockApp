using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Data.Migrations
{
    public partial class mig03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockTypeId",
                table: "StockUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_StockTypeId",
                table: "StockUnits",
                column: "StockTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockUnits_StockTypes_StockTypeId",
                table: "StockUnits",
                column: "StockTypeId",
                principalTable: "StockTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockUnits_StockTypes_StockTypeId",
                table: "StockUnits");

            migrationBuilder.DropIndex(
                name: "IX_StockUnits_StockTypeId",
                table: "StockUnits");

            migrationBuilder.DropColumn(
                name: "StockTypeId",
                table: "StockUnits");
        }
    }
}
