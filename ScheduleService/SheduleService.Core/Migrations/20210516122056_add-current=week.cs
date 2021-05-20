using Microsoft.EntityFrameworkCore.Migrations;

namespace SheduleService.Core.Migrations
{
    public partial class addcurrentweek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentWeekNumbers",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentWeekNumbers");
        }
    }
}
