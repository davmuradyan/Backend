namespace Backend.Core.Services.GPSModelServices {
    public record CreateGPSModelDto {
        public required string Model { get; set; }
        public int ManufacturerID { get; set; }
        public int ApiSupportLevel { get; set; }
        public double AccuracyMeters { get; set; }
        public double UpdateIntervalSec { get; set; }
    }
}
