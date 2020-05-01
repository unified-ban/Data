using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanMakeTelegramReportChatIdLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ReportChatId",
                schema: "dbo",
                table: "Group_TelegramGroup",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReportChatId",
                schema: "dbo",
                table: "Group_TelegramGroup",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
