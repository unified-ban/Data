using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddIndexOnTelegramChatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Group_TelegramGroup_TelegramChatId",
                schema: "dbo",
                table: "Group_TelegramGroup",
                column: "TelegramChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Group_TelegramGroup_TelegramChatId",
                schema: "dbo",
                table: "Group_TelegramGroup");
        }
    }
}
