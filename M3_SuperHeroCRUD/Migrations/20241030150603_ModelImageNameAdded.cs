using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M3_SuperHeroCRUD.Migrations
{
    public partial class ModelImageNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "SuperHeroes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "SuperHeroes");
        }
    }
}
