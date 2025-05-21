namespace Backend.Core.Services.GpsModelGNSSServices {
    public record CreateGpsModelGNSSDto {
        public int GPSModelID { get; set; }
        public int GNSSSystemID { get; set; }
    }
}
