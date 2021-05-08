using Microsoft.EntityFrameworkCore.Migrations;

namespace SheduleService.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    lesson_id = table.Column<string>(nullable: false),
                    group_id = table.Column<string>(nullable: true),
                    day_number = table.Column<string>(nullable: true),
                    day_name = table.Column<string>(nullable: true),
                    lesson_name = table.Column<string>(nullable: true),
                    lesson_full_name = table.Column<string>(nullable: true),
                    lesson_number = table.Column<string>(nullable: true),
                    lesson_room = table.Column<string>(nullable: true),
                    lesson_type = table.Column<string>(nullable: true),
                    teacher_name = table.Column<string>(nullable: true),
                    lesson_week = table.Column<string>(nullable: true),
                    time_start = table.Column<string>(nullable: true),
                    time_end = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.lesson_id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    teacher_id = table.Column<string>(nullable: false),
                    teacher_name = table.Column<string>(nullable: true),
                    teacher_full_name = table.Column<string>(nullable: true),
                    teacher_short_name = table.Column<string>(nullable: true),
                    teacher_url = table.Column<string>(nullable: true),
                    teacher_rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherOnLessons",
                columns: table => new
                {
                    Teacher_Id = table.Column<string>(nullable: false),
                    Lesson_Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherOnLessons", x => new { x.Lesson_Id, x.Teacher_Id });
                    table.ForeignKey(
                        name: "FK_TeacherOnLessons_Lessons_Lesson_Id",
                        column: x => x.Lesson_Id,
                        principalTable: "Lessons",
                        principalColumn: "lesson_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherOnLessons_Teachers_Teacher_Id",
                        column: x => x.Teacher_Id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherOnLessons_Teacher_Id",
                table: "TeacherOnLessons",
                column: "Teacher_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherOnLessons");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
