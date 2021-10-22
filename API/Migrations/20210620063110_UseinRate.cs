using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UseinRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "productRatings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "productRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productRatings_AppUserId",
                table: "productRatings",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_productRatings_AspNetUsers_AppUserId",
                table: "productRatings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_AspNetUsers_AppUserId",
                table: "productRatings");

            migrationBuilder.DropIndex(
                name: "IX_productRatings_AppUserId",
                table: "productRatings");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "productRatings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "productRatings");
        }
    }
}
