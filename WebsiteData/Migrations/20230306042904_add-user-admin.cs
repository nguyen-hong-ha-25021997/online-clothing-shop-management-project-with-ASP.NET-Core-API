using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteData.Migrations
{
    public partial class adduseradmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string sql = "Insert into Account(DateCreated, DateModified,UserName, NormalizedUserName,Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)" +
                "values(getdate(), getdate(), 'admin', 'ADMIN','admin@exam.com', 'ADMIN@EXAM.COM', 0, 'AQAAAAEAACcQAAAAELwA2c/jJic3BZsdZpqef7OuDQVhETtTGHhJK/Ofr9YmAq07CyWflrOiekB3A00N1A==', 'NKGSMPQ27A7XKCYRNDEDTL4HOXKHNYZU', 'ffcfe9a8-f096-4a26-b8d9-d957e4e9d7b3', '123456789', 0, 0, NULL, 1, 0)";
                   
               
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
