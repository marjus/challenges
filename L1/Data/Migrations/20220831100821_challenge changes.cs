using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L1.Data.Migrations
{
    public partial class challengechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyLevelId",
                table: "Challenges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Challenges",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Challenges");
        }
    }
}
