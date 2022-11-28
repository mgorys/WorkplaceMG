using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkplaceMG.Migrations
{
    public partial class StockCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "Equipments",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Equipments");
        }
    }
}
