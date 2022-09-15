using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MoneyMgmt.DAL.Models
{
    public partial class MoneyManagementContext : DbContext
    {
        public MoneyManagementContext()
        {
        }

        public MoneyManagementContext(DbContextOptions<MoneyManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserCategory> UserCategories { get; set; }
        public virtual DbSet<UserRecord> UserRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Carrot;Initial Catalog=MoneyManagement;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Label).HasMaxLength(255);
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.DateOfIssue).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Records_Accounts");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Records_Categories");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CurrencyUnit)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(N'VND')");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'User')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("UserAccount");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccount_Accounts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccount_Users");
            });

            modelBuilder.Entity<UserCategory>(entity =>
            {
                entity.ToTable("UserCategory");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.UserCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCategory_Categories");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCategories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserCategory_Users");
            });

            modelBuilder.Entity<UserRecord>(entity =>
            {
                entity.ToTable("UserRecord");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.UserRecords)
                    .HasForeignKey(d => d.RecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRecord_Records");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRecords)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRecord_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
