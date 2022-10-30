using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthPlus.Migrations
{
    public partial class migration_30_10_2022_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "goal",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "information",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "goal",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "information",
                table: "Users");
        }
    }
}
