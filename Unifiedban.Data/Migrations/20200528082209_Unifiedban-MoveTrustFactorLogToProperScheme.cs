using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanMoveTrustFactorLogToProperScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TrustFactorLog",
                schema: "dbo",
                newName: "TrustFactorLog",
                newSchema: "log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TrustFactorLog",
                schema: "log",
                newName: "TrustFactorLog",
                newSchema: "dbo");
        }
    }
}
