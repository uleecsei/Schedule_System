using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SheduleService.Core.Migrations
{
    public partial class totallogicchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonInformations_Lessons_LessonId",
                table: "LessonInformations");

            migrationBuilder.DropIndex(
                name: "IX_LessonInformations_LessonId",
                table: "LessonInformations");

            migrationBuilder.DropColumn(
                name: "lesson_date",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "LessonInformations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Lessons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Lessons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentSchedule",
                table: "Lessons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LessonInHistoryId",
                table: "LessonInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LessonInHistories",
                columns: table => new
                {
                    LessonInHistoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lesson_id = table.Column<int>(nullable: false),
                    lesson_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonInHistories", x => x.LessonInHistoryId);
                    table.ForeignKey(
                        name: "FK_LessonInHistories_Lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "Lessons",
                        principalColumn: "lesson_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonInformations_LessonInHistoryId",
                table: "LessonInformations",
                column: "LessonInHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonInHistories_lesson_id",
                table: "LessonInHistories",
                column: "lesson_id");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonInformations_LessonInHistories_LessonInHistoryId",
                table: "LessonInformations",
                column: "LessonInHistoryId",
                principalTable: "LessonInHistories",
                principalColumn: "LessonInHistoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonInformations_LessonInHistories_LessonInHistoryId",
                table: "LessonInformations");

            migrationBuilder.DropTable(
                name: "LessonInHistories");

            migrationBuilder.DropIndex(
                name: "IX_LessonInformations_LessonInHistoryId",
                table: "LessonInformations");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "IsCurrentSchedule",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonInHistoryId",
                table: "LessonInformations");

            migrationBuilder.AddColumn<DateTime>(
                name: "lesson_date",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "LessonInformations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LessonInformations_LessonId",
                table: "LessonInformations",
                column: "LessonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonInformations_Lessons_LessonId",
                table: "LessonInformations",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "lesson_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
