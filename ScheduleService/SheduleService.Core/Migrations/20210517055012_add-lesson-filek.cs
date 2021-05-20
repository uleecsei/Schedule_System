using Microsoft.EntityFrameworkCore.Migrations;

namespace SheduleService.Core.Migrations
{
    public partial class addlessonfilek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherOnLessons_Lessons_Lesson_Id",
                table: "TeacherOnLessons");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherOnLessons_Lessons_Lesson_Id",
                table: "TeacherOnLessons",
                column: "Lesson_Id",
                principalTable: "Lessons",
                principalColumn: "lesson_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherOnLessons_Lessons_Lesson_Id",
                table: "TeacherOnLessons");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherOnLessons_Lessons_Lesson_Id",
                table: "TeacherOnLessons",
                column: "Lesson_Id",
                principalTable: "Lessons",
                principalColumn: "lesson_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
