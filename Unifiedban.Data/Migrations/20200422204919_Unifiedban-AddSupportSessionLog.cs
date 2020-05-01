using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddSupportSessionLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportSession",
                schema: "log",
                columns: table => new
                {
                    LogId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    SenderId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportSession", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_SupportSession_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportSession_GroupId",
                schema: "log",
                table: "SupportSession",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportSession",
                schema: "log");
        }
    }
}
