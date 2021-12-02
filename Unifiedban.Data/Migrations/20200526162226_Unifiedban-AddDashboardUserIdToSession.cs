using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddDashboardUserIdToSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DashboardUserId",
                schema: "dbo",
                table: "DashboardSession",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardSession_DashboardUserId",
                schema: "dbo",
                table: "DashboardSession",
                column: "DashboardUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DashboardSession_Group_DashboardUser_DashboardUserId",
                schema: "dbo",
                table: "DashboardSession",
                column: "DashboardUserId",
                principalSchema: "dbo",
                principalTable: "Group_DashboardUser",
                principalColumn: "DashboardUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DashboardSession_Group_DashboardUser_DashboardUserId",
                schema: "dbo",
                table: "DashboardSession");

            migrationBuilder.DropIndex(
                name: "IX_DashboardSession_DashboardUserId",
                schema: "dbo",
                table: "DashboardSession");

            migrationBuilder.DropColumn(
                name: "DashboardUserId",
                schema: "dbo",
                table: "DashboardSession");
        }
    }
}
