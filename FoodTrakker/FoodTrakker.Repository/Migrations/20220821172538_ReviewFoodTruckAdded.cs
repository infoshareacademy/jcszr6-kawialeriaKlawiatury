using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrakker.Repository.Migrations
{
    public partial class ReviewFoodTruckAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTruckId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "a679cd48-87e7-42d5-bd72-d3f0379bfe5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "ec96a4d5-05c1-4350-a2f5-a77225f4cc2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "ea2c2014-3135-4186-83bc-cb7d8063181b");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews",
                column: "FoodTruckId",
                principalTable: "FoodTrucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "FoodTruckId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "e843c86d-5958-4aea-a7fc-52d6d22804a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "ec74f740-1a83-4af5-9e79-69bc72ad9551");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "be87d2f6-8ca3-4182-b4ac-73976475e531");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews",
                column: "FoodTruckId",
                principalTable: "FoodTrucks",
                principalColumn: "Id");
        }
    }
}
