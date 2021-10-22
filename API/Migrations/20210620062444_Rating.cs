using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_Products_ProductsModelId",
                table: "productRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_StarRatting_StarRattingRateId",
                table: "productRatings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "productRatings");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "productRatings");

            migrationBuilder.RenameColumn(
                name: "StarRattingRateId",
                table: "productRatings",
                newName: "productIdId");

            migrationBuilder.RenameColumn(
                name: "ProductsModelId",
                table: "productRatings",
                newName: "StarRattingIdRateId");

            migrationBuilder.RenameIndex(
                name: "IX_productRatings_StarRattingRateId",
                table: "productRatings",
                newName: "IX_productRatings_productIdId");

            migrationBuilder.RenameIndex(
                name: "IX_productRatings_ProductsModelId",
                table: "productRatings",
                newName: "IX_productRatings_StarRattingIdRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_productRatings_Products_productIdId",
                table: "productRatings",
                column: "productIdId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productRatings_StarRatting_StarRattingIdRateId",
                table: "productRatings",
                column: "StarRattingIdRateId",
                principalTable: "StarRatting",
                principalColumn: "RateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_Products_productIdId",
                table: "productRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_StarRatting_StarRattingIdRateId",
                table: "productRatings");

            migrationBuilder.RenameColumn(
                name: "productIdId",
                table: "productRatings",
                newName: "StarRattingRateId");

            migrationBuilder.RenameColumn(
                name: "StarRattingIdRateId",
                table: "productRatings",
                newName: "ProductsModelId");

            migrationBuilder.RenameIndex(
                name: "IX_productRatings_StarRattingIdRateId",
                table: "productRatings",
                newName: "IX_productRatings_ProductsModelId");

            migrationBuilder.RenameIndex(
                name: "IX_productRatings_productIdId",
                table: "productRatings",
                newName: "IX_productRatings_StarRattingRateId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "productRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "productRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_productRatings_Products_ProductsModelId",
                table: "productRatings",
                column: "ProductsModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productRatings_StarRatting_StarRattingRateId",
                table: "productRatings",
                column: "StarRattingRateId",
                principalTable: "StarRatting",
                principalColumn: "RateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
