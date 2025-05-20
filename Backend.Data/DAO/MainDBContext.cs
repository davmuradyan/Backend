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
    }
}