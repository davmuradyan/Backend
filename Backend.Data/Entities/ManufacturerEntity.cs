using System.Diagnostics.Metrics;

namespace Backend.Data.Entities {
    public class ManufacturerEntity {
        public int ManufacturerID { get; set; }
        public required string Name { get; set; }
        public int CountryID { get; set; }
        public CountryEntity? Country { get; set; }

        public ICollection<GPSModelEntity>? GPSModels { get; set; }
        public ICollection<VehicleTypeEntity>? VehicleTypes { get; set; }
    }
}