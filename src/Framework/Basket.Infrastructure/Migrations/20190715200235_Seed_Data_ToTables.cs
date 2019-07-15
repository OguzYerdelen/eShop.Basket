using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket.Infrastructure.Migrations
{
    public partial class Seed_Data_ToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedBy", "ModifiedBy" },
                values: new object[] { 1, "Laptop", "Oğuz Berkay Yerdelen", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[] { 1, "Oğuz Berkay", "Yerdelen" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "ModifiedBy", "ProductName", "UnitPrice", "UnitsInStock" },
                values: new object[] { 1, 1, "Oğuz Berkay Yerdelen", null, "MSI", 1000.0, 500m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
