using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteData.Migrations
{
    public partial class product_quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Product_Quantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Quantity",
                table: "Product");
        }
    }
}
