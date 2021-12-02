using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanMakeTelegramChatIdLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Group_TelegramGroup_TelegramChatId",
                schema: "dbo",
                table: "Group_TelegramGroup");

            migrationBuilder.AlterColumn<long>(
                name: "TelegramChatId",
                schema: "dbo",
                table: "Group_TelegramGroup",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TelegramChatId",
                schema: "dbo",
                table: "Group_TelegramGroup",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Group_TelegramGroup_TelegramChatId",
                schema: "dbo",
                table: "Group_TelegramGroup",
                column: "TelegramChatId");
        }
    }
}
