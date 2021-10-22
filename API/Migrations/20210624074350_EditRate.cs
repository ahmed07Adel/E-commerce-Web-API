using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EditRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_Products_productIdId",
                table: "productRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_StarRatting_StarRattingIdRateId",
                table: "productRatings");

            migrationBuilder.DropTable(
                name: "StarRatting");

            migrationBuilder.DropIndex(
                name: "IX_productRatings_StarRattingIdRateId",
                table: "productRatings");

            migrationBuilder.DropColumn(
                name: "StarRattingIdRateId",
                table: "productRatings");

            migrationBuilder.RenameColumn(
                name: "productIdId",
                table: "productRatings",
                newName: "ProductsModelId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "productRatings",
                newName: "Rate");

            migrationBuilder.RenameIndex(
                name: "IX_productRatings_productIdId",
                table: "productRatings",
                newName: "IX_productRatings_ProductsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_productRatings_Products_ProductsModelId",
                table: "productRatings",
                column: "ProductsModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productRatings_Products_ProductsModelId",
                table: "productRatings");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "productRatings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProductsModelId",
                table: "productRatings",
                newName: "productIdId");

            migrationBuilder.RenameIndex(
                name: "IX_productRatings_ProductsModelId",
                table: "productRatings",
                newName: "IX_productRatings_productIdId");

            migrationBuilder.AddColumn<int>(
                name: "StarRattingIdRateId",
                table: "productRatings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StarRatting",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRatting", x => x.RateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productRatings_StarRattingIdRateId",
                table: "productRatings",
                column: "StarRattingIdRateId");

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
    }
}
