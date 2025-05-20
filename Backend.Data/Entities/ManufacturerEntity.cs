using System.Diagnostics.Metrics;

namespace Backend.Data.Entities {
    public class ManufacturerEntity {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public CountryEntity Country { get; set; }

        public ICollection<GPSModel> GPSModels { get; set; }
        public ICollection<VehicleType> VehicleTypes { get; set; }
    }
}