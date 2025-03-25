using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.DAO {
    public class MainDBContext : DbContext {
        public MainDBContext(DbContextOptions options) : base(options) { }

        public DbSet<StopEntity> Stops { get; set; }
        public DbSet<EdgeEntity> Edges { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<RouteEdgeEntity> RouteEdges { get; set; }
        public DbSet<BusEntity> Buses { get; set; }
        public DbSet<DriverEntity> Drivers { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EdgeEntity>()
                .HasOne(e => e.Start_stop)
                .WithMany(s => s.StartEdges)
                .HasForeignKey(e => e.Start_stop_id)
                .OnDelete(DeleteBehavior.NoAction);  // No cascading delete

            modelBuilder.Entity<EdgeEntity>()
                .HasOne(e => e.End_stop)
                .WithMany(s => s.EndEdges)
                .HasForeignKey(e => e.End_stop_id)
                .OnDelete(DeleteBehavior.NoAction);  // No cascading delete
        }
    }
}