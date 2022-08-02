using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrakker.Repository.Migrations
{
    public partial class addDataToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "c66ccb01-ffbd-4abc-8de1-580052b9926a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "98abbef5-361b-4dec-b719-0b80faa38691");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "9ce54af7-8a34-40c9-b76c-5858f6ade93a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "b69b2ac4-5d92-47ac-bc10-42e58e5cd930");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "2c43e2b1-cffd-4478-8aeb-5fb62363e357");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "ecaf7648-df37-45cc-90e7-250c51f2865d");
        }
    }
}
