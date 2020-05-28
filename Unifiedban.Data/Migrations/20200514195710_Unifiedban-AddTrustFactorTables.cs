using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddTrustFactorTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_TrustFactor",
                schema: "dbo",
                columns: table => new
                {
                    TrustFactorId = table.Column<string>(maxLength: 100, nullable: false),
                    TelegramUserId = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_TrustFactor", x => x.TrustFactorId);
                });

            migrationBuilder.CreateTable(
                name: "TrustFactorLog",
                schema: "dbo",
                columns: table => new
                {
                    TrustFactorLogId = table.Column<string>(maxLength: 100, nullable: false),
                    TrustFactorId = table.Column<string>(maxLength: 100, nullable: true),
                    Action = table.Column<int>(nullable: false),
                    ActionTakenBy = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustFactorLog", x => x.TrustFactorLogId);
                    table.ForeignKey(
                        name: "FK_TrustFactorLog_User_TrustFactor_TrustFactorId",
                        column: x => x.TrustFactorId,
                        principalSchema: "dbo",
                        principalTable: "User_TrustFactor",
                        principalColumn: "TrustFactorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrustFactorLog_TrustFactorId",
                schema: "dbo",
                table: "TrustFactorLog",
                column: "TrustFactorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrustFactorLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_TrustFactor",
                schema: "dbo");
        }
    }
}
