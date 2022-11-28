using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkplaceMG.Migrations
{
    public partial class countR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "EquipmentForWorkplaces");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "EquipmentForWorkplaces",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
