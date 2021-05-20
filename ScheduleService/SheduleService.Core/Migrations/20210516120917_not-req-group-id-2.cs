using Microsoft.EntityFrameworkCore.Migrations;

namespace SheduleService.Core.Migrations
{
    public partial class notreqgroupid2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "group_id",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "group_id",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
