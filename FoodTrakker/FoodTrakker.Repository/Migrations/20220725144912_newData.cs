using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrakker.Repository.Migrations
{
    public partial class newData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "f7eb409e-f25c-429e-9fd0-7f7aa3aa8bb2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "5650cf3e-5c24-471e-b49e-0ea7b37b8d68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "1301845a-d108-4322-bb91-e407a53e7804");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "d128a8f8-503b-48a8-9e50-9e08200f0420");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "5ae2d922-9f57-47cf-9290-f30b49363bbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "1fd724a7-6de7-4c49-af1d-774d0282114a");
        }
    }
}
