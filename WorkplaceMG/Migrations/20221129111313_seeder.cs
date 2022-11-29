using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkplaceMG.Migrations
{
    public partial class seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Antony", "Hopkins" },
                    { 2, "Tom", "Hanks" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "StockCount", "Type" },
                values: new object[,]
                {
                    { 1, 3, "Headphones" },
                    { 2, 3, "Keyboard" },
                    { 3, 3, "Mouse" }
                });

            migrationBuilder.InsertData(
                table: "Workplaces",
                columns: new[] { "Id", "Floor", "Room", "Table" },
                values: new object[,]
                {
                    { 1, 0, 1, 1 },
                    { 2, 0, 1, 2 },
                    { 3, 0, 2, 1 },
                    { 4, 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "EquipmentForWorkplaces",
                columns: new[] { "Id", "IdEquipment", "IdWorkplace" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 2 },
                    { 5, 1, 3 },
                    { 6, 2, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EquipmentForWorkplaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EquipmentForWorkplaces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EquipmentForWorkplaces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EquipmentForWorkplaces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EquipmentForWorkplaces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EquipmentForWorkplaces",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workplaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workplaces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workplaces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workplaces",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
