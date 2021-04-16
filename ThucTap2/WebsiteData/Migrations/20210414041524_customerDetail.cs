using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteData.Migrations
{
    public partial class customerDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerMobile",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerMobile",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Order");
        }
    }
}
