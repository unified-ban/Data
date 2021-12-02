using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddGroupConfigurationDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group_DefaultConfigParameter",
                schema: "config",
                columns: table => new
                {
                    ConfigurationParameterId = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Values = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_DefaultConfigParameter", x => x.ConfigurationParameterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group_DefaultConfigParameter",
                schema: "config");
        }
    }
}
