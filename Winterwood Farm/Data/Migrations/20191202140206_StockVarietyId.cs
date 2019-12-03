using Microsoft.EntityFrameworkCore.Migrations;

namespace Winterwood_Farm.Data.Migrations
{
    public partial class StockVarietyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "StockVarietyId",
                table: "StockModel",
                columns: new[] { "Fruit", "Variety" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "StockVarietyId",
                table: "StockModel");
        }
    }
}
