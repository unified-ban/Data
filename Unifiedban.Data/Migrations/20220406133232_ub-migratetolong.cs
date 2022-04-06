using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class ubmigratetolong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TelegramUserId",
                schema: "dbo",
                table: "DashboardSession",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TelegramUserId",
                schema: "dbo",
                table: "DashboardSession",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
