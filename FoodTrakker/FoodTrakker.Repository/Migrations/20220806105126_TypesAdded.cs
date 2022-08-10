using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrakker.Repository.Migrations
{
    public partial class TypesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "d0b61d37-46e6-47a9-8796-8465cc02a91f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "f08da352-1d25-46bb-8715-b4861190ce2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "dc522967-ce9a-4b05-a014-abef413da3f1");

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Fast Food" },
                    { 9, "Würst" },
                    { 10, "Fusion" },
                    { 11, "Regional" },
                    { 12, "Midterranean" },
                    { 13, "Indian" },
                    { 14, "Spanish" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "1cc61d66-c250-44ee-a73e-9462a5ffb125");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "f0cd1190-bb39-4855-b87a-63d780e8abee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "a330ba19-b695-4f3b-9f55-1cde8db3a5ef");
        }
    }
}
