﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unifiedban.Data;

namespace Unifiedban.Data.Migrations
{
    [DbContext(typeof(UBContext))]
    partial class UBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Unifiedban.Models.ActionLog", b =>
                {
                    b.Property<string>("ActionLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActionTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ActionLogId");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("GroupId");

                    b.ToTable("Action","log");
                });

            modelBuilder.Entity("Unifiedban.Models.ActionType", b =>
                {
                    b.Property<string>("ActionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActionTypeId");

                    b.ToTable("ActionType","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Button", b =>
                {
                    b.Property<string>("ButtonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Scope")
                        .HasColumnType("int");

                    b.HasKey("ButtonId");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name");

                    b.HasIndex("GroupId", "Name");

                    b.ToTable("Button","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.DashboardSession", b =>
                {
                    b.Property<string>("DashboardSessionId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("DashboardUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TelegramFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelegramLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelegramPhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.Property<string>("TelegramUsername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DashboardSessionId");

                    b.HasIndex("DashboardUserId");

                    b.ToTable("DashboardSession","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.BadImage", b =>
                {
                    b.Property<string>("BadImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FlipType")
                        .HasColumnType("int");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HashData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Match")
                        .HasColumnType("int");

                    b.Property<string>("ParentImageId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BadImageId");

                    b.HasIndex("GroupId");

                    b.ToTable("Filter_BadImage","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.BadWord", b =>
                {
                    b.Property<string>("BadWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Match")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Regex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BadWordId");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name");

                    b.ToTable("Filter_BadWord","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Filters.SafeTName", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("TelegramChatId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Username", "TelegramChatId");

                    b.HasIndex("TelegramChatId");

                    b.ToTable("Filter_SafeTName","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.ConfigurationParameter", b =>
                {
                    b.Property<string>("ConfigurationParameterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Values")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConfigurationParameterId");

                    b.ToTable("Group_DefaultConfigParameter","config");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.DashboardPermission", b =>
                {
                    b.Property<string>("DashboardPermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DashboardUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastUpdateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("DashboardPermissionId");

                    b.HasIndex("DashboardUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupId", "DashboardUserId");

                    b.ToTable("Group_DashboardPermission","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.DashboardUser", b =>
                {
                    b.Property<string>("DashboardUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastActionUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.HasKey("DashboardUserId");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("Group_DashboardUser","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.NightSchedule", b =>
                {
                    b.Property<string>("NightScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UtcEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UtcStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NightScheduleId");

                    b.HasIndex("GroupId");

                    b.ToTable("Group_NightSchedule","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.Note", b =>
                {
                    b.Property<string>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NoteId");

                    b.HasIndex("GroupId");

                    b.HasIndex("Tag");

                    b.HasIndex("GroupId", "Tag");

                    b.ToTable("Group_Note","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.SafeGroup", b =>
                {
                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GroupId", "GroupName");

                    b.ToTable("Group_SafeGroup","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.Group.TelegramGroup", b =>
                {
                    b.Property<string>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChatLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Configuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InviteAlias")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("InviteLink")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<long>("ReportChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("RulesText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SettingsLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<long>("TelegramChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WelcomeText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.HasIndex("TelegramChatId");

                    b.ToTable("Group_TelegramGroup","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.OperationLog", b =>
                {
                    b.Property<string>("OperationLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OperationLogId");

                    b.HasIndex("GroupId");

                    b.ToTable("Operation","log");
                });

            modelBuilder.Entity("Unifiedban.Models.Operator", b =>
                {
                    b.Property<string>("OperatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.HasKey("OperatorId");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("Operator","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.SupportSessionLog", b =>
                {
                    b.Property<string>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("LogId");

                    b.HasIndex("GroupId");

                    b.ToTable("SupportSession","log");
                });

            modelBuilder.Entity("Unifiedban.Models.SysConfig", b =>
                {
                    b.Property<string>("SysConfigId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SysConfigId");

                    b.ToTable("SysConfig","config");
                });

            modelBuilder.Entity("Unifiedban.Models.SystemLog", b =>
                {
                    b.Property<int>("SystemLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Function")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("LoggerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SystemLogId");

                    b.ToTable("System","log");
                });

            modelBuilder.Entity("Unifiedban.Models.Translation.Entry", b =>
                {
                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("KeyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Translation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId", "KeyId");

                    b.HasIndex("KeyId");

                    b.ToTable("Entry","lang");
                });

            modelBuilder.Entity("Unifiedban.Models.Translation.Key", b =>
                {
                    b.Property<string>("KeyId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("KeyId");

                    b.ToTable("Key","lang");
                });

            modelBuilder.Entity("Unifiedban.Models.Translation.Language", b =>
                {
                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UniversalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
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
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<int>("ActionTakenBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrustFactorId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("TrustFactorLogId");

                    b.HasIndex("TrustFactorId");

                    b.ToTable("TrustFactorLog","log");
                });

            modelBuilder.Entity("Unifiedban.Models.User.Banned", b =>
                {
                    b.Property<int>("TelegramUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Reason")
                        .HasColumnType("int");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TelegramUserId");

                    b.ToTable("User_Banned","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.User.Flood", b =>
                {
                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TelegramUserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("User_Flood","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.User.TempKicked", b =>
                {
                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TelegramUserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("User_TempKicked","dbo");
                });

            modelBuilder.Entity("Unifiedban.Models.User.TrustFactor", b =>
                {
                    b.Property<string>("TrustFactorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Unifiedban.Models.DashboardSession", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.DashboardUser", "DashboardUser")
                        .WithMany()
                        .HasForeignKey("DashboardUserId");
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unifiedban.Models.Translation.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Unifiedban.Models.User.TempKicked", b =>
                {
                    b.HasOne("Unifiedban.Models.Group.TelegramGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
