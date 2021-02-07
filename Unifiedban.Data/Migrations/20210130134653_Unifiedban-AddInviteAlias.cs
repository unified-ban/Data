using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddInviteAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InviteAlias",
                schema: "dbo",
                table: "Group_TelegramGroup",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InviteLink",
                schema: "dbo",
                table: "Group_TelegramGroup",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InviteAlias",
                schema: "dbo",
                table: "Group_TelegramGroup");

            migrationBuilder.DropColumn(
                name: "InviteLink",
                schema: "dbo",
                table: "Group_TelegramGroup");
        }
    }
}
