using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Data.Migrations
{
    public partial class mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "StockUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StockClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_CurrencyId",
                table: "StockUnits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_QuantityUnitId",
                table: "StockUnits",
                column: "QuantityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockClassId",
                table: "Stocks",
                column: "StockClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockTypeId",
                table: "Stocks",
                column: "StockTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_StockClasses_StockClassId",
                table: "Stocks",
                column: "StockClassId",
                principalTable: "StockClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_StockTypes_StockTypeId",
                table: "Stocks",
                column: "StockTypeId",
                principalTable: "StockTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockUnits_Currencies_CurrencyId",
                table: "StockUnits",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockUnits_QuantityUnits_QuantityUnitId",
                table: "StockUnits",
                column: "QuantityUnitId",
                principalTable: "QuantityUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_StockClasses_StockClassId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_StockTypes_StockTypeId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_StockUnits_Currencies_CurrencyId",
                table: "StockUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_StockUnits_QuantityUnits_QuantityUnitId",
                table: "StockUnits");

            migrationBuilder.DropTable(
                name: "StockClasses");

            migrationBuilder.DropIndex(
                name: "IX_StockUnits_CurrencyId",
                table: "StockUnits");

            migrationBuilder.DropIndex(
                name: "IX_StockUnits_QuantityUnitId",
                table: "StockUnits");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_StockClassId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_StockTypeId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "StockUnits");
        }
    }
}
