using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SheduleService.Core.Migrations
{
    public partial class AddLessonDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "lesson_date",
                table: "Lessons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lesson_date",
                table: "Lessons");
        }
    }
}
