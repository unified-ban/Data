using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unifiedban.Data.Migrations
{
    public partial class UnifiedbanFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ActionType",
                schema: "dbo",
                columns: table => new
                {
                    ActionTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Group_DashboardUser",
                schema: "dbo",
                columns: table => new
                {
                    DashboardUserId = table.Column<string>(nullable: false),
                    TelegramUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    LastActionUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_DashboardUser", x => x.DashboardUserId);
                });

            migrationBuilder.CreateTable(
                name: "Group_TelegramGroup",
                schema: "dbo",
                columns: table => new
                {
                    GroupId = table.Column<string>(nullable: false),
                    TelegramChatId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Configuration = table.Column<string>(nullable: true),
                    WelcomeText = table.Column<string>(nullable: true),
                    ChatLanguage = table.Column<string>(nullable: true),
                    SettingsLanguage = table.Column<string>(nullable: true),
                    ReportChatId = table.Column<int>(nullable: false),
                    RulesText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_TelegramGroup", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Operator",
                schema: "dbo",
                columns: table => new
                {
                    OperatorId = table.Column<string>(nullable: false),
                    TelegramUserId = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.OperatorId);
                });

            migrationBuilder.CreateTable(
                name: "System",
                schema: "log",
                columns: table => new
                {
                    SystemLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoggerName = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System", x => x.SystemLogId);
                });

            migrationBuilder.CreateTable(
                name: "Button",
                schema: "dbo",
                columns: table => new
                {
                    ButtonId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Scope = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Button", x => x.ButtonId);
                    table.ForeignKey(
                        name: "FK_Button_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filter_BadImage",
                schema: "dbo",
                columns: table => new
                {
                    BadImageId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    ParentImageId = table.Column<string>(maxLength: 100, nullable: true),
                    HashData = table.Column<string>(nullable: true),
                    FlipType = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UtcDate = table.Column<DateTime>(nullable: false),
                    Match = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter_BadImage", x => x.BadImageId);
                    table.ForeignKey(
                        name: "FK_Filter_BadImage_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filter_BadWord",
                schema: "dbo",
                columns: table => new
                {
                    BadWordId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Regex = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UtcDate = table.Column<DateTime>(nullable: false),
                    Match = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter_BadWord", x => x.BadWordId);
                    table.ForeignKey(
                        name: "FK_Filter_BadWord_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group_DashboardPermission",
                schema: "dbo",
                columns: table => new
                {
                    DashboardPermissionId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    DashboardUserId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    LastUpdateUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_DashboardPermission", x => x.DashboardPermissionId);
                    table.ForeignKey(
                        name: "FK_Group_DashboardPermission_Group_DashboardUser_DashboardUserId",
                        column: x => x.DashboardUserId,
                        principalSchema: "dbo",
                        principalTable: "Group_DashboardUser",
                        principalColumn: "DashboardUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Group_DashboardPermission_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group_NightSchedule",
                schema: "dbo",
                columns: table => new
                {
                    NightScheduleId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    UtcStartDate = table.Column<DateTime>(nullable: false),
                    UtcEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_NightSchedule", x => x.NightScheduleId);
                    table.ForeignKey(
                        name: "FK_Group_NightSchedule_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group_Note",
                schema: "dbo",
                columns: table => new
                {
                    NoteId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Note", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Group_Note_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group_SafeGroup",
                schema: "dbo",
                columns: table => new
                {
                    GroupId = table.Column<string>(nullable: false),
                    GroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_SafeGroup", x => new { x.GroupId, x.GroupName });
                    table.ForeignKey(
                        name: "FK_Group_SafeGroup_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "User_Flood",
                schema: "dbo",
                columns: table => new
                {
                    TelegramUserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<string>(nullable: false),
                    UtcDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Flood", x => new { x.TelegramUserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_User_Flood_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_TempKicked",
                schema: "dbo",
                columns: table => new
                {
                    TelegramUserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<string>(nullable: false),
                    UtcDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_TempKicked", x => new { x.TelegramUserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_User_TempKicked_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "log",
                columns: table => new
                {
                    ActionLogId = table.Column<string>(nullable: false),
                    ActionTypeId = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    Parameters = table.Column<string>(nullable: true),
                    UtcDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.ActionLogId);
                    table.ForeignKey(
                        name: "FK_Action_ActionType_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalSchema: "dbo",
                        principalTable: "ActionType",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Action_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                schema: "log",
                columns: table => new
                {
                    OperationLogId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    TelegramUserId = table.Column<int>(nullable: false),
                    Action = table.Column<string>(maxLength: 200, nullable: true),
                    Parameters = table.Column<string>(maxLength: 400, nullable: true),
                    UtcDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.OperationLogId);
                    table.ForeignKey(
                        name: "FK_Operation_Group_TelegramGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group_TelegramGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Button_GroupId",
                schema: "dbo",
                table: "Button",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Button_Name",
                schema: "dbo",
                table: "Button",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Button_GroupId_Name",
                schema: "dbo",
                table: "Button",
                columns: new[] { "GroupId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Filter_BadImage_GroupId",
                schema: "dbo",
                table: "Filter_BadImage",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_BadWord_GroupId",
                schema: "dbo",
                table: "Filter_BadWord",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_BadWord_Name",
                schema: "dbo",
                table: "Filter_BadWord",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Group_DashboardPermission_DashboardUserId",
                schema: "dbo",
                table: "Group_DashboardPermission",
                column: "DashboardUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_DashboardPermission_GroupId",
                schema: "dbo",
                table: "Group_DashboardPermission",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_DashboardPermission_GroupId_DashboardUserId",
                schema: "dbo",
                table: "Group_DashboardPermission",
                columns: new[] { "GroupId", "DashboardUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Group_DashboardUser_TelegramUserId",
                schema: "dbo",
                table: "Group_DashboardUser",
                column: "TelegramUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_NightSchedule_GroupId",
                schema: "dbo",
                table: "Group_NightSchedule",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Note_GroupId",
                schema: "dbo",
                table: "Group_Note",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Note_Tag",
                schema: "dbo",
                table: "Group_Note",
                column: "Tag");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Note_GroupId_Tag",
                schema: "dbo",
                table: "Group_Note",
                columns: new[] { "GroupId", "Tag" });

            migrationBuilder.CreateIndex(
                name: "IX_Group_TelegramGroup_TelegramChatId",
                schema: "dbo",
                table: "Group_TelegramGroup",
                column: "TelegramChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Operator_TelegramUserId",
                schema: "dbo",
                table: "Operator",
                column: "TelegramUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_User_Flood_GroupId",
                schema: "dbo",
                table: "User_Flood",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TempKicked_GroupId",
                schema: "dbo",
                table: "User_TempKicked",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_ActionTypeId",
                schema: "log",
                table: "Action",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_GroupId",
                schema: "log",
                table: "Action",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_GroupId",
                schema: "log",
                table: "Operation",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Button",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Filter_BadImage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Filter_BadWord",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Group_DashboardPermission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Group_NightSchedule",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Group_Note",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Group_SafeGroup",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Operator",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_Banned",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_Flood",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_TempKicked",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Action",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Operation",
                schema: "log");

            migrationBuilder.DropTable(
                name: "System",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Group_DashboardUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ActionType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Group_TelegramGroup",
                schema: "dbo");
        }
    }
}
