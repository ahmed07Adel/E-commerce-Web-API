using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Edit5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Productincarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Productincarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
