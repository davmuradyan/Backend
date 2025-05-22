namespace Backend.Core.Services.GpsRelated.GPSModelServices
{
    public record UpdateGPSModelDto
    {
        public string? Model { get; set; }
        public int? ManufacturerID { get; set; }
        public int? ApiSupportLevel { get; set; }
        public double? AccuracyMeters { get; set; }
        public double? UpdateIntervalSec { get; set; }
    }
}
