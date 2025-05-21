namespace Backend.Data.Entities {
    public class GPSModelEntity {
        public int GPSModelID { get; set; }
        public required string Model { get; set; }
        public int ManufacturerID { get; set; }
        public int ApiSupportLevel { get; set; }
        public double AccuracyMeters { get; set; }
        public double UpdateIntervalSec { get; set; }

        public ManufacturerEntity? Manufacturer { get; set; }
        public ICollection<GpsModelGNSSEntity>? GNSSSystems { get; set; }
    }
}