using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteData.Migrations
{
    public partial class _18_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product_Style",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Style",
                table: "Product");
        }
    }
}
