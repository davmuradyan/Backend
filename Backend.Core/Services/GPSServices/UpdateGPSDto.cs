namespace Backend.Core.Services.GPSServices {
    public record UpdateGPSDto {
        public string? ID { get; set; }
        public int? GPSModelID { get; set; }
    }
}
