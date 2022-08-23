using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalago_Blazor.Server.Migrations
{
    public partial class CriaRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06bd509a-3330-4f8a-a719-c43a73fb8ef5", "9d6329df-e317-4300-8199-6c8e7883859a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18e9ecfc-fc49-44b6-b6ac-17a08b9f3f15", "9f0646a8-2864-490d-952d-18f9a9a0d53b", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06bd509a-3330-4f8a-a719-c43a73fb8ef5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18e9ecfc-fc49-44b6-b6ac-17a08b9f3f15");
        }
    }
}
