using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrakker.Repository.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FoodTruckId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "FoodTruckUser",
                columns: table => new
                {
                    FavouriteFoodTrucksId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTruckUser", x => new { x.FavouriteFoodTrucksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_FoodTruckUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodTruckUser_FoodTrucks_FavouriteFoodTrucksId",
                        column: x => x.FavouriteFoodTrucksId,
                        principalTable: "FoodTrucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c69-021b-1234-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "ee0361b9-f068-4e69-9336-5a65b68e1c42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "6a56d4f5-256f-4780-975c-45626223fca1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "d28039d1-a1e0-4e28-ab51-087d82f6f1f7");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FoodTruckId",
                table: "Reviews",
                column: "FoodTruckId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTruckUser_UsersId",
                table: "FoodTruckUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews",
                column: "FoodTruckId",
                principalTable: "FoodTrucks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_FoodTrucks_FoodTruckId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "FoodTruckUser");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_FoodTruckId",
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
                value: "48233b77-f56e-4f6e-8647-2e276b1ebecc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df456c89-021b-4342-a852-b32678f1alec",
                column: "ConcurrencyStamp",
                value: "a45f6d0f-1d72-4435-bdf2-5f73be6341f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df510c89-042b-4342-a852-b32678f1c1ce",
                column: "ConcurrencyStamp",
                value: "3dbb0b01-585e-4e5d-a22a-4341045521d4");
        }
    }
}
