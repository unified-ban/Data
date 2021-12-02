using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddSafeTelegramNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filter_SafeTName",
                schema: "dbo",
                columns: table => new
                {
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    TelegramChatId = table.Column<long>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter_SafeTName", x => new { x.Username, x.TelegramChatId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filter_SafeTName_TelegramChatId",
                schema: "dbo",
                table: "Filter_SafeTName",
                column: "TelegramChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filter_SafeTName",
                schema: "dbo");
        }
    }
}
