using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EditShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productincarts_ShoppingCartItems_CartitemItemId",
                table: "Productincarts");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Productincarts_CartitemItemId",
                table: "Productincarts");

            migrationBuilder.DropColumn(
                name: "CartitemItemId",
                table: "Productincarts");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "Productincarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Productincarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Productincarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Productincarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productincarts_AppUserId",
                table: "Productincarts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productincarts_AspNetUsers_AppUserId",
                table: "Productincarts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productincarts_AspNetUsers_AppUserId",
                table: "Productincarts");

            migrationBuilder.DropIndex(
                name: "IX_Productincarts_AppUserId",
                table: "Productincarts");

            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "Productincarts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Productincarts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Productincarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Productincarts");

            migrationBuilder.AddColumn<int>(
                name: "CartitemItemId",
                table: "Productincarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productincarts_CartitemItemId",
                table: "Productincarts",
                column: "CartitemItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Productincarts_ShoppingCartItems_CartitemItemId",
                table: "Productincarts",
                column: "CartitemItemId",
                principalTable: "ShoppingCartItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
