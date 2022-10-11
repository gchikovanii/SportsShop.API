using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsShop.Infrastructure.Migrations
{
    public partial class ProductEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Product");
        }
    }
}
