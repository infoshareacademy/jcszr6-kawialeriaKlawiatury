using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrakker.Repository.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "6a6736e7-8276-4d43-a28b-6f505f2baf61");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "d0313098-767a-4aa0-bedd-59e4960044fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "18f74454-4c7b-48ce-914a-11df9a0e639a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "aeae6455-4fb1-4be9-84cd-1c42d676193e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "1f7310e8-2712-45f4-a085-b07e209d772d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "3106b425-4ca0-47f0-aa24-ba6576697e57");
        }
    }
}
