using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRM_ProjectAPI.Models
{
    public partial class PRM_JourneyToTheWestContext : DbContext
    {
        public PRM_JourneyToTheWestContext()
        {
        }

        public PRM_JourneyToTheWestContext(DbContextOptions<PRM_JourneyToTheWestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorScenarioDetail> ActorScenarioDetails { get; set; }
        public virtual DbSet<Scenario> Scenarios { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<ToolScenarioDetail> ToolScenarioDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=PRM391_Final");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.ActorId)
                    .HasColumnName("ActorID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActorNavigation)
                    .WithOne(p => p.Actor)
                    .HasForeignKey<Actor>(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actor_Account");
            });

            modelBuilder.Entity<ActorScenarioDetail>(entity =>
            {
                entity.HasKey(e => new { e.ScenarioId, e.ActorId })
                    .HasName("PK_FileDescriptionPath");

                entity.ToTable("ActorScenarioDetail");

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");

                entity.Property(e => e.ActorId)
                    .HasColumnName("ActorID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FileDescriptionPath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorScenarioDetails)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorScenarioDetail_Actor");

                entity.HasOne(d => d.Scenario)
                    .WithMany(p => p.ActorScenarioDetails)
                    .HasForeignKey(d => d.ScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorScenarioDetail_Scenario");
            });

            modelBuilder.Entity<Scenario>(entity =>
            {
                entity.ToTable("Scenario");

                entity.Property(e => e.ScenarioId)
                    .HasColumnName("ScenarioID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EndOnDt)
                    .HasColumnName("EndOnDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.FileDescriptionPath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ScenarioName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.StartOnDt)
                    .HasColumnName("StartOnDT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.ToTable("Tool");

                entity.Property(e => e.ToolId)
                    .HasColumnName("ToolID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ToolName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ToolScenarioDetail>(entity =>
            {
                entity.HasKey(e => new { e.ScenarioId, e.ToolId });

                entity.ToTable("ToolScenarioDetail");

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");

                entity.Property(e => e.ToolId).HasColumnName("ToolID");

                entity.HasOne(d => d.Scenario)
                    .WithMany(p => p.ToolScenarioDetails)
                    .HasForeignKey(d => d.ScenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolScenarioDetail_Scenario");

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.ToolScenarioDetails)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolScenarioDetail_Tool");
            });
        }
    }
}
