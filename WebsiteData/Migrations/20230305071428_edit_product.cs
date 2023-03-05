using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteData.Migrations
{
    public partial class edit_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Show",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Product_Style",
                table: "Product",
                newName: "Product_Unit");

            migrationBuilder.RenameColumn(
                name: "Product_Size",
                table: "Product",
                newName: "Product_Detail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Order_DeliveryTime",
                table: "Order",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product_Unit",
                table: "Product",
                newName: "Product_Style");

            migrationBuilder.RenameColumn(
                name: "Product_Detail",
                table: "Product",
                newName: "Product_Size");

            migrationBuilder.DropColumn(
                name: "Product_Show",
                table: "Product");
        }
    }
}
