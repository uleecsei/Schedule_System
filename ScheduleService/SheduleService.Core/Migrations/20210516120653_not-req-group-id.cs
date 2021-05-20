using Microsoft.EntityFrameworkCore.Migrations;

namespace SheduleService.Core.Migrations
{
    public partial class notreqgroupid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_group_id",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_group_id",
                table: "AspNetUsers",
                column: "group_id",
                principalTable: "Groups",
                principalColumn: "group_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_group_id",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_group_id",
                table: "AspNetUsers",
                column: "group_id",
                principalTable: "Groups",
                principalColumn: "group_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
