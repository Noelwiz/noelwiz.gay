using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataLayer.Models;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Context
{
    public partial class postgresContext : DbContext
    {

        private string ConnectionString;

        public postgresContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        #region tables
        public virtual DbSet<Blogpost> Blogposts { get; set; } = null!;
        public virtual DbSet<Character> Characters { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Playground> Playgrounds { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Ship> Ships { get; set; } = null!;
        public virtual DbSet<ShipRating> ShipRatings { get; set; } = null!;
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogpost>(entity =>
            {
                entity.ToTable("blogposts", "blog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasIndex(e => e.Name, "Characters_Name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("Characters_Owner_fkey");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.DiscordUser)
                    .HasName("Owners_pkey");
            });

            modelBuilder.Entity<Playground>(entity =>
            {
                entity.HasKey(e => e.EquipId)
                    .HasName("playground_pkey");

                entity.ToTable("playground");

                entity.Property(e => e.EquipId).HasColumnName("equip_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(25)
                    .HasColumnName("color");

                entity.Property(e => e.InstallDate).HasColumnName("install_date");

                entity.Property(e => e.Location)
                    .HasMaxLength(25)
                    .HasColumnName("location");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roles", "SiteAuthentication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rolename)
                    .HasColumnType("character varying")
                    .HasColumnName("rolename");
            });

            modelBuilder.Entity<Ship>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.HasOne(d => d.Character1Navigation)
                    .WithMany(p => p.ShipCharacter1Navigations)
                    .HasForeignKey(d => d.Character1)
                    .HasConstraintName("Ships_Character1_fkey");

                entity.HasOne(d => d.Character2Navigation)
                    .WithMany(p => p.ShipCharacter2Navigations)
                    .HasForeignKey(d => d.Character2)
                    .HasConstraintName("Ships_Character2_fkey");
            });

            modelBuilder.Entity<ShipRating>(entity =>
            {
                entity.HasKey(e => new { e.Rater, e.Ship })
                    .HasName("ShipRaitingsPK");

                entity.HasOne(d => d.RaterNavigation)
                    .WithMany(p => p.ShipRatings)
                    .HasForeignKey(d => d.Rater)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ShipRatings_Rater_fkey");

                entity.HasOne(d => d.ShipNavigation)
                    .WithMany(p => p.ShipRatings)
                    .HasForeignKey(d => d.Ship)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ShipRatings_Ship_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
