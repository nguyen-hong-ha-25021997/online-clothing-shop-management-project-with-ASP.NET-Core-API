using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteData.Migrations
{
    public partial class sale_price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Product_SalePrice",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_SalePrice",
                table: "Product");
        }
    }
}
