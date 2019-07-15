using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket.Infrastructure.Migrations
{
    public partial class CountOfProduct_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfProduct",
                table: "Baskets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfProduct",
                table: "Baskets");
        }
    }
}
