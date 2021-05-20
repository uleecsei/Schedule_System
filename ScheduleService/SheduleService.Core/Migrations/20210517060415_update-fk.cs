using Microsoft.EntityFrameworkCore.Migrations;

namespace SheduleService.Core.Migrations
{
    public partial class updatefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_group_id",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_group_id",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_group_id",
                table: "Lessons",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_group_id",
                table: "AspNetUsers",
                column: "group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_group_id",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_group_id",
                table: "AspNetUsers");

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
        }
    }
}
