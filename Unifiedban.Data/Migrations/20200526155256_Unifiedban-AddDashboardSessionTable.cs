using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddDashboardSessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardSession",
                schema: "dbo",
                columns: table => new
                {
                    DashboardSessionId = table.Column<string>(maxLength: 100, nullable: false),
                    StartDateUtc = table.Column<DateTime>(nullable: false),
                    TelegramUserId = table.Column<int>(nullable: false),
                    TelegramFirstName = table.Column<string>(nullable: true),
                    TelegramLastName = table.Column<string>(nullable: true),
                    TelegramPhotoUrl = table.Column<string>(nullable: true),
                    TelegramUsername = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardSession", x => x.DashboardSessionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardSession",
                schema: "dbo");
        }
    }
}
