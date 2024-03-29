﻿/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using Microsoft.EntityFrameworkCore;
using Unifiedban.Models;
using Unifiedban.Models.Translation;
using Unifiedban.Models.User;
using Unifiedban.Models.Group;
using Unifiedban.Models.Filters;

namespace Unifiedban.Data
{
    public class UBContext : DbContext
    {
        static string ConnectionString = @"Server=NB-PDC\LOCDEV17;Database=Unifiedban_V2_Dev;Trusted_Connection=True";
        public UBContext()
        { }
        public UBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public UBContext(DbContextOptions<UBContext> options)
            : base(options)
        { }

        #region " log "
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<OperationLog> OperationLogs { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<SupportSessionLog> SupportSessionLogs { get; set; }
        public DbSet<TrustFactorLog> TrustFactorLogs { get; set; }
        #endregion

        #region " Config "
        public DbSet<SysConfig> SysConfigs { get; set; }
        public DbSet<ConfigurationParameter> Group_ConfigurationParameters { get; set; }
        #endregion

        #region " dbo "
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<Button> Buttons { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<DashboardSession> DashboardSessions { get; set; }

        #region " Translation / Lang "
        public DbSet<Language> Languages { get; set; }
        public DbSet<Key> TranslationKeys { get; set; }
        public DbSet<Entry> TranslationEntries { get; set; }
        #endregion

        #region " User "
        public DbSet<Banned> Users_Banned { get; set; }
        public DbSet<Flood> Users_Flood { get; set; }
        public DbSet<TempKicked> Users_TempKicked { get; set; }
        public DbSet<TrustFactor> Users_TrustFactor { get; set; }
        #endregion

        #region " Group "
        public DbSet<TelegramGroup> Group_TelegramGroups { get; set; }
        public DbSet<DashboardUser> Group_DashboardUsers { get; set; }
        public DbSet<DashboardPermission> Group_DashboardPermissions { get; set; }
        public DbSet<Note> Group_Notes { get; set; }
        public DbSet<SafeGroup> Group_SafeGroups { get; set; }
        public DbSet<NightSchedule> Group_NightSchedules { get; set; }
        #endregion

        #region " Filters "
        public DbSet<BadWord> BadWords { get; set; }
        public DbSet<BadImage> BadImages { get; set; }
        public DbSet<SafeTName> SafeTNames { get; set; }
        #endregion

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entry>()
                .HasKey(c => new { c.LanguageId, c.KeyId });

            modelBuilder.Entity<Language>()
                .HasData(
                new Language()
                {
                    LanguageId = "en",
                    Name = "English",
                    Status = Language.State.NotRready,
                    UniversalCode = "en-GB"
                }
            );
            modelBuilder.Entity<Language>()
                .HasData(
                new Language()
                {
                    LanguageId = "it",
                    Name = "Italiano",
                    Status = Language.State.NotRready,
                    UniversalCode = "it-IT"
                }
            );

            modelBuilder.Entity<Operator>()
                .HasIndex(x => x.TelegramUserId);

            modelBuilder.Entity<Button>()
                .HasIndex(x => new { x.GroupId, x.Name });
            modelBuilder.Entity<Button>()
                .HasIndex(x => x.GroupId);
            modelBuilder.Entity<Button>()
                .HasIndex(x => x.Name);

            OnModelCreating_User(modelBuilder);
            OnModelCreating_Group(modelBuilder);
            OnModelCreating_Filters(modelBuilder);

            modelBuilder.Entity<SupportSessionLog>()
                .HasKey(x => x.LogId);
        }

        private void OnModelCreating_User(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TempKicked>()
                .HasKey(x => new { x.TelegramUserId, x.GroupId });

            modelBuilder.Entity<Flood>()
                .HasKey(x => new { x.TelegramUserId, x.GroupId });
        }

        private void OnModelCreating_Group(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelegramGroup>()
                .HasIndex(x => x.TelegramChatId);

            modelBuilder.Entity<DashboardUser>()
                .HasIndex(x => x.TelegramUserId);

            modelBuilder.Entity<DashboardPermission>()
                .HasIndex(x => new { x.GroupId, x.DashboardUserId });
            modelBuilder.Entity<DashboardPermission>()
                .HasIndex(x => x.GroupId);
            modelBuilder.Entity<DashboardPermission>()
                .HasIndex(x => x.DashboardUserId);

            modelBuilder.Entity<SafeGroup>()
                .HasKey(x => new { x.GroupId, x.GroupName });

            modelBuilder.Entity<NightSchedule>()
                .HasIndex(x => x.GroupId);

            modelBuilder.Entity<Note>()
                .HasIndex(x => new { x.GroupId, x.Tag });
            modelBuilder.Entity<Note>()
                .HasIndex(x => x.GroupId);
            modelBuilder.Entity<Note>()
                .HasIndex(x => x.Tag);
        }

        private void OnModelCreating_Filters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadWord>()
                .HasIndex(x => x.GroupId);
            modelBuilder.Entity<BadWord>()
                .HasIndex(x => x.Name);

            modelBuilder.Entity<BadImage>()
                .HasIndex(x => x.GroupId);

            modelBuilder.Entity<SafeTName>()
                .HasKey(x => new { x.Username, x.TelegramChatId });
            modelBuilder.Entity<SafeTName>()
                .HasIndex(x => x.TelegramChatId);
        }

    }
}
