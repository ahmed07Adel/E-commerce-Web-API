using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserGenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserGenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGenders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserGenders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "UserGenders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Female" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserGenderId",
                table: "AspNetUsers",
                column: "UserGenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserGenders_UserGenderId",
                table: "AspNetUsers",
                column: "UserGenderId",
                principalTable: "UserGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserGenders_UserGenderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserGenders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserGenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserGenderId",
                table: "AspNetUsers");
        }
    }
}
