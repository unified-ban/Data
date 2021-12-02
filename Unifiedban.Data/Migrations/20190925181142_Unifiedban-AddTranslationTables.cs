using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanAddTranslationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lang");

            migrationBuilder.CreateTable(
                name: "Key",
                schema: "lang",
                columns: table => new
                {
                    KeyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "lang",
                columns: table => new
                {
                    LanguageId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UniversalCode = table.Column<string>(maxLength: 20, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                schema: "lang",
                columns: table => new
                {
                    LanguageId = table.Column<string>(nullable: false),
                    KeyId = table.Column<string>(nullable: false),
                    Translation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => new { x.LanguageId, x.KeyId });
                    table.ForeignKey(
                        name: "FK_Entry_Key_KeyId",
                        column: x => x.KeyId,
                        principalSchema: "lang",
                        principalTable: "Key",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entry_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "lang",
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "lang",
                table: "Language",
                columns: new[] { "LanguageId", "Name", "Status", "UniversalCode" },
                values: new object[] { "en", "English", 0, "en-GB" });

            migrationBuilder.InsertData(
                schema: "lang",
                table: "Language",
                columns: new[] { "LanguageId", "Name", "Status", "UniversalCode" },
                values: new object[] { "it", "Italiano", 0, "it-IT" });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_KeyId",
                schema: "lang",
                table: "Entry",
                column: "KeyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "Key",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "lang");
        }
    }
}
