using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SheduleService.Core.Migrations
{
    public partial class addlessoninformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "LessonInformations",
                columns: table => new
                {
                    LessonInformationId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ConferenceUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonInformations", x => x.LessonInformationId);
                    table.ForeignKey(
                        name: "FK_LessonInformations_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "lesson_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_group_id",
                table: "Lessons",
                column: "group_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_group_id",
                table: "AspNetUsers",
                column: "group_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonInformations_LessonId",
                table: "LessonInformations",
                column: "LessonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_group_id",
                table: "AspNetUsers",
                column: "group_id",
                principalTable: "Groups",
                principalColumn: "group_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_group_id",
                table: "Lessons",
                column: "group_id",
                principalTable: "Groups",
                principalColumn: "group_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_group_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_group_id",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "LessonInformations");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_group_id",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_group_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }
    }
}
