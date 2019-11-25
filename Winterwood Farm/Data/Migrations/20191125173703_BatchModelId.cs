using Microsoft.EntityFrameworkCore.Migrations;

namespace Winterwood_Farm.Data.Migrations
{
    public partial class BatchModelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StockModel",
                newName: "StockModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BatchModel",
                newName: "BatchModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockModelId",
                table: "StockModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BatchModelId",
                table: "BatchModel",
                newName: "Id");
        }
    }
}
