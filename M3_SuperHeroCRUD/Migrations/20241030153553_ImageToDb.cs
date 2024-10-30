using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M3_SuperHeroCRUD.Migrations
{
    public partial class ImageToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "SuperHeroes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "SuperHeroes");
        }
    }
}
