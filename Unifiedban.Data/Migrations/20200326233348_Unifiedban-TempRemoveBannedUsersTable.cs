using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanTempRemoveBannedUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Banned",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Banned",
                schema: "dbo",
                columns: table => new
                {
                    TelegramUserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<string>(nullable: false),
                    BannerUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Reason = table.Column<int>(nullable: false),
                    UtcDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Banned", x => new { x.TelegramUserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_User_Banned_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Banned_GroupId",
                schema: "dbo",
                table: "User_Banned",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Banned_TelegramUserId",
                schema: "dbo",
                table: "User_Banned",
                column: "TelegramUserId");
        }
    }
}
