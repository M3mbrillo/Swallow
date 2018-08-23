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
        public virtual DbSet<Trip> Trip { get; set; }

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

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasIndex(e => new { e.OriginLatitude, e.OriginLongitude, e.ArrivalLatitude, e.ArrivalLongitude })
                    .HasName("UQ_OriginArrival")
                    .IsUnique();
            });
        }
    }
}
