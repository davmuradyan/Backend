namespace Backend.Core.Services.GPSServices {
    public record CreateGPSDto {
        public required string ID { get; set; }
        public int GPSModelID { get; set; }
    }
}
