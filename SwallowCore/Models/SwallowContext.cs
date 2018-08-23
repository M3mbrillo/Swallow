using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SwallowCore.Models
{
    public partial class SwallowContext : DbContext
    {
        public SwallowContext()
        {
        }

        public SwallowContext(DbContextOptions<SwallowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EstimatePrice> EstimatePrice { get; set; }
        public virtual DbSet<MapMarker> MapMarker { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<TravelRoad> TravelRoad { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Settings.SwallowCoreSettings.SwallowDatabase.ConnectionStrings);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstimatePrice>(entity =>
            {
                entity.HasKey(e => new { e.StartDateTime, e.TripId, e.ProductId });

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.EstimatePrice)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EstimateP__IdTri__628FA481");
            });

            modelBuilder.Entity<MapMarker>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.MapMarker)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MapMarker_User_Id");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Travel)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Travel_User_Id");
            });

            modelBuilder.Entity<TravelRoad>(entity =>
            {
                entity.HasKey(e => new { e.TravelId, e.OriginMapMarkerId, e.ArrivalMapMarkerId });

                entity.HasOne(d => d.ArrivalMapMarker)
                    .WithMany(p => p.TravelRoadArrivalMapMarker)
                    .HasForeignKey(d => d.ArrivalMapMarkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelRoad_ArrivalMapMarker_Id");

                entity.HasOne(d => d.OriginMapMarker)
                    .WithMany(p => p.TravelRoadOriginMapMarker)
                    .HasForeignKey(d => d.OriginMapMarkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelRoad_OriginMapMarker_Id");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.TravelRoad)
                    .HasForeignKey(d => d.TravelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelRoad_Travel_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TravelRoad)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelRoad_User_Id");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasIndex(e => new { e.OriginLatitude, e.OriginLongitude, e.ArrivalLatitude, e.ArrivalLongitude })
                    .HasName("UQ_OriginArrival")
                    .IsUnique();
            });
        }
    }
}
