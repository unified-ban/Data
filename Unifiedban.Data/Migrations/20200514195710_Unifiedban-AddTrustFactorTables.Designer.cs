﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unifiedban.Data;

namespace Unifiedban.Data.Migrations
{
    [DbContext(typeof(UBContext))]
    [Migration("20200514195710_Unifiedban-AddTrustFactorTables")]
    partial class UnifiedbanAddTrustFactorTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Unifiedban.Models.ActionLog", b =>
                {
                    b.Property<string>("ActionLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionTypeId");

                    b.Property<string>("GroupId");

                    b.Property<string>("Parameters");

                    b.Property<DateTime>("UtcDate");

                    b.HasKey("ActionLogId");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("GroupId");

                    b.ToTable("Action","log");
                });

            modelBuilder.Entity("Unifiedban.Models.ActionType", b =>
                {
                    b.Property<string>("ActionTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ActionTypeId");

                    b.ToTable("ActionType","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Button", b =>
                {
                    b.Property<string>("ButtonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("GroupId");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("Scope");

                    b.HasKey("ButtonId");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name");

                    b.HasIndex("GroupId", "Name");

                    b.ToTable("Button","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.BadImage", b =>
                {
                    b.Property<string>("BadImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlipType");

                    b.Property<string>("GroupId");

                    b.Property<string>("HashData");

                    b.Property<int>("Match");

                    b.Property<string>("ParentImageId")
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.Property<DateTime>("UtcDate");

                    b.HasKey("BadImageId");

                    b.HasIndex("GroupId");

                    b.ToTable("Filter_BadImage","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.BadWord", b =>
                {
                    b.Property<string>("BadWordId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupId");

                    b.Property<int>("Match");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Regex");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UtcDate");

                    b.HasKey("BadWordId");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name");

                    b.ToTable("Filter_BadWord","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.SafeTName", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(100);

                    b.Property<long>("TelegramChatId");

                    b.Property<DateTime>("RecordDate");

                    b.HasKey("Username", "TelegramChatId");

                    b.HasIndex("TelegramChatId");

                    b.ToTable("Filter_SafeTName","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.ConfigurationParameter", b =>
                {
                    b.Property<string>("ConfigurationParameterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.Property<string>("Value");

                    b.Property<string>("Values");

                    b.HasKey("ConfigurationParameterId");

                    b.ToTable("Group_DefaultConfigParameter","config");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.DashboardPermission", b =>
                {
                    b.Property<string>("DashboardPermissionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DashboardUserId");

                    b.Property<string>("GroupId");

                    b.Property<DateTime>("LastUpdateUtc");

                    b.Property<int>("State");

                    b.HasKey("DashboardPermissionId");

                    b.HasIndex("DashboardUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupId", "DashboardUserId");

                    b.ToTable("Group_DashboardPermission","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.DashboardUser", b =>
                {
                    b.Property<string>("DashboardUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastActionUtc");

                    b.Property<string>("Name");

                    b.Property<string>("ProfilePicture");

                    b.Property<int>("TelegramUserId");

                    b.HasKey("DashboardUserId");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("Group_DashboardUser","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.NightSchedule", b =>
                {
                    b.Property<string>("NightScheduleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupId");

                    b.Property<int>("State");

                    b.Property<DateTime?>("UtcEndDate");

                    b.Property<DateTime?>("UtcStartDate");

                    b.HasKey("NightScheduleId");

                    b.HasIndex("GroupId");

                    b.ToTable("Group_NightSchedule","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.Note", b =>
                {
                    b.Property<string>("NoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupId");

                    b.Property<string>("Message");

                    b.Property<string>("Tag");

                    b.HasKey("NoteId");

                    b.HasIndex("GroupId");

                    b.HasIndex("Tag");

                    b.HasIndex("GroupId", "Tag");

                    b.ToTable("Group_Note","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.SafeGroup", b =>
                {
                    b.Property<string>("GroupId");

                    b.Property<string>("GroupName");

                    b.HasKey("GroupId", "GroupName");

                    b.ToTable("Group_SafeGroup","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.TelegramGroup", b =>
                {
                    b.Property<string>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChatLanguage");

                    b.Property<string>("Configuration");

                    b.Property<long>("ReportChatId");

                    b.Property<string>("RulesText");

                    b.Property<string>("SettingsLanguage");

                    b.Property<int>("State");

                    b.Property<long>("TelegramChatId");

                    b.Property<string>("Title");

                    b.Property<string>("WelcomeText");

                    b.HasKey("GroupId");

                    b.HasIndex("TelegramChatId");

                    b.ToTable("Group_TelegramGroup","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.OperationLog", b =>
                {
                    b.Property<string>("OperationLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .HasMaxLength(200);

                    b.Property<string>("GroupId");

                    b.Property<string>("Parameters")
                        .HasMaxLength(400);

                    b.Property<int>("TelegramUserId");

                    b.Property<DateTime>("UtcDate");

                    b.HasKey("OperationLogId");

                    b.HasIndex("GroupId");

                    b.ToTable("Operation","log");
                });

            modelBuilder.Entity("Unifiedban.Models.Operator", b =>
                {
                    b.Property<string>("OperatorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Level");

                    b.Property<int>("TelegramUserId");

                    b.HasKey("OperatorId");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("Operator","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.SupportSessionLog", b =>
                {
                    b.Property<string>("LogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupId");

                    b.Property<int>("SenderId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("Type");

                    b.HasKey("LogId");

                    b.HasIndex("GroupId");

                    b.ToTable("SupportSession","log");
                });

            modelBuilder.Entity("Unifiedban.Models.SysConfig", b =>
                {
                    b.Property<string>("SysConfigId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Value");

                    b.HasKey("SysConfigId");

                    b.ToTable("SysConfig","config");
                });

            modelBuilder.Entity("Unifiedban.Models.SystemLog", b =>
                {
                    b.Property<int>("SystemLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Function");

                    b.Property<int>("Level");

                    b.Property<string>("LoggerName");

                    b.Property<string>("Message");

                    b.Property<int>("UserId");

                    b.HasKey("SystemLogId");

                    b.ToTable("System","log");
                });

            modelBuilder.Entity("Unifiedban.Models.Translation.Entry", b =>
                {
                    b.Property<string>("LanguageId");

                    b.Property<string>("KeyId");

                    b.Property<string>("Translation");

                    b.HasKey("LanguageId", "KeyId");

                    b.HasIndex("KeyId");

                    b.ToTable("Entry","lang");
                });

            modelBuilder.Entity("Unifiedban.Models.Translation.Key", b =>
                {
                    b.Property<string>("KeyId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("KeyId");

                    b.ToTable("Key","lang");
                });

            modelBuilder.Entity("Unifiedban.Models.Translation.Language", b =>
                {
                    b.Property<string>("LanguageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.Property<string>("UniversalCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("LanguageId");

                    b.ToTable("Language","lang");

                    b.HasData(
                        new
                        {
                            LanguageId = "en",
                            Name = "English",
                            Status = 0,
                            UniversalCode = "en-GB"
                        },
                        new
                        {
                            LanguageId = "it",
                            Name = "Italiano",
                            Status = 0,
                            UniversalCode = "it-IT"
                        });
                });

            modelBuilder.Entity("Unifiedban.Models.TrustFactorLog", b =>
                {
                    b.Property<string>("TrustFactorLogId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<int>("Action");

                    b.Property<int>("ActionTakenBy");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("TrustFactorId")
                        .HasMaxLength(100);

                    b.HasKey("TrustFactorLogId");

                    b.HasIndex("TrustFactorId");

                    b.ToTable("TrustFactorLog","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.User.Banned", b =>
                {
                    b.Property<int>("TelegramUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Reason");

                    b.Property<DateTime>("UtcDate");

                    b.HasKey("TelegramUserId");

                    b.ToTable("User_Banned","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.User.Flood", b =>
                {
                    b.Property<int>("TelegramUserId");

                    b.Property<string>("GroupId");

                    b.Property<DateTime>("UtcDate");

                    b.HasKey("TelegramUserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("User_Flood","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.User.TempKicked", b =>
                {
                    b.Property<int>("TelegramUserId");

                    b.Property<string>("GroupId");

                    b.Property<DateTime>("UtcDate");

                    b.HasKey("TelegramUserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("User_TempKicked","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.User.TrustFactor", b =>
                {
                    b.Property<string>("TrustFactorId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<int>("Points");

                    b.Property<int>("TelegramUserId");

                    b.HasKey("TrustFactorId");

                    b.ToTable("User_TrustFactor","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.ActionLog", b =>
                {
                    b.HasOne("Unifiedban.Models.ActionType", "ActionType")
                        .WithMany()
                        .HasForeignKey("ActionTypeId");

                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Button", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.BadImage", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.BadWord", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.DashboardPermission", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.DashboardUser", "DashboardUser")
                        .WithMany()
                        .HasForeignKey("DashboardUserId");

                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.NightSchedule", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.Note", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.SafeGroup", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Unifiedban.Models.OperationLog", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.SupportSessionLog", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Unifiedban.Models.Translation.Entry", b =>
                {
                    b.HasOne("Unifiedban.Models.Translation.Key", "Key")
                        .WithMany()
                        .HasForeignKey("KeyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Unifiedban.Models.Translation.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Unifiedban.Models.TrustFactorLog", b =>
                {
                    b.HasOne("Unifiedban.Models.User.TrustFactor", "TrustFactor")
                        .WithMany()
                        .HasForeignKey("TrustFactorId");
                });

            modelBuilder.Entity("Unifiedban.Models.User.Flood", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Unifiedban.Models.User.TempKicked", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
