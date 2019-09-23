using System;
using Microsoft.EntityFrameworkCore;
using Unifiedban.Models;
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
        #endregion

        #region " dbo "
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<Button> Buttons { get; set; }
        public DbSet<Operator> Operators { get; set; }

        #region " User "
        public DbSet<Banned> Users_Banned { get; set; }
        public DbSet<Flood> Users_Flood { get; set; }
        public DbSet<TempKicked> Users_TempKicked { get; set; }
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
        #endregion

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString,
                options => options.EnableRetryOnFailure(3));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }

        private void OnModelCreating_User(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TempKicked>()
                .HasKey(x => new { x.TelegramUserId, x.GroupId });

            modelBuilder.Entity<Flood>()
                .HasKey(x => new { x.TelegramUserId, x.GroupId });

            modelBuilder.Entity<Banned>()
                .HasKey(x => new { x.TelegramUserId, x.GroupId });
            modelBuilder.Entity<Banned>()
                .HasIndex(x => x.GroupId);
            modelBuilder.Entity<Banned>()
                .HasIndex(x => x.TelegramUserId);
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
        }

    }
}
