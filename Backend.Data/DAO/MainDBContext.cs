using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.DAO {
    public class MainDBContext : DbContext {
        public MainDBContext(DbContextOptions options) : base(options) { }

        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<DriverEntity> Drivers { get; set; }
        public DbSet<EdgeEntity> Edges { get; set; }
        public DbSet<GPSEntity> GPSDevices { get; set; }
        public DbSet<GPSModelEntity> GPSModels { get; set; }
        public DbSet<GpsModelGNSSEntity> GpsModelGNSS { get; set; }
        public DbSet<GNSSSystemEntity> GNSSSystems { get; set; }
        public DbSet<LicenceEntity> Licences { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<RouteEdgeEntity> RouteEdges { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<StopEntity> Stops { get; set; }
        public DbSet<TripEntity> Trips { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserFeedbackEntity> UserFeedbacks { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<VehicleTypeEntity> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AdminEntity>().HasKey(e => e.AdminID);
            modelBuilder.Entity<CityEntity>().HasKey(e => e.CityID);
            modelBuilder.Entity<CountryEntity>().HasKey(e => e.CountryID);
            modelBuilder.Entity<DriverEntity>().HasKey(e => e.DriverID);
            modelBuilder.Entity<EdgeEntity>().HasKey(e => e.EdgeID);
            modelBuilder.Entity<GNSSSystemEntity>().HasKey(e => e.GNSSSystemID);
            modelBuilder.Entity<GPSEntity>().HasKey(e => e.GpsID);
            modelBuilder.Entity<GPSModelEntity>().HasKey(e => e.GPSModelID);
            modelBuilder.Entity<GpsModelGNSSEntity>().HasKey(e => e.ID);
            modelBuilder.Entity<LicenceEntity>().HasKey(e => e.LicenceID);
            modelBuilder.Entity<ManufacturerEntity>().HasKey(e => e.ManufacturerID);
            modelBuilder.Entity<RegionEntity>().HasKey(e => e.RegionID);
            modelBuilder.Entity<RouteEdgeEntity>().HasKey(e => e.REID);
            modelBuilder.Entity<RouteEntity>().HasKey(e => e.RouteID);
            modelBuilder.Entity<StopEntity>().HasKey(e => e.StopID);
            modelBuilder.Entity<TripEntity>().HasKey(e => e.TripID);
            modelBuilder.Entity<UserEntity>().HasKey(e => e.UserID);
            modelBuilder.Entity<UserFeedbackEntity>().HasKey(e => e.UserFeedbackID);
            modelBuilder.Entity<VehicleEntity>().HasKey(e => e.VehicleID);
            modelBuilder.Entity<VehicleTypeEntity>().HasKey(e => e.VehicleTypeID);

            modelBuilder.Entity<GpsModelGNSSEntity>()
                .HasOne(x => x.GPSModel)
                .WithMany()
                .HasForeignKey(x => x.GPSModelID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GpsModelGNSSEntity>()
                .HasOne(x => x.GNSSSystem)
                .WithMany()
                .HasForeignKey(x => x.GNSSSystemID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VehicleEntity>()
                .HasOne(v => v.City)
                .WithMany()
                .HasForeignKey(v => v.CityID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VehicleEntity>()
                .HasOne(v => v.VehicleType)
                .WithMany()
                .HasForeignKey(v => v.VehicleTypeID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TripEntity>()
                .HasOne(t => t.StartStop)
                .WithMany()
                .HasForeignKey(t => t.StartStopID)
                .OnDelete(DeleteBehavior.Restrict); // OR .NoAction

            modelBuilder.Entity<TripEntity>()
                .HasOne(t => t.EndStop)
                .WithMany()
                .HasForeignKey(t => t.EndStopID)
                .OnDelete(DeleteBehavior.Cascade); // This one keeps cascade if needed

        }
    }
}