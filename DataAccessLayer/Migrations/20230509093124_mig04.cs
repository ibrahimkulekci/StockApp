using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Data.Migrations
{
    public partial class mig04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockId",
                table: "StockUnits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "StockUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
