namespace Backend.Core.Services.GpsRelated.GpsModelGNSSServices
{
    public record CreateGpsModelGNSSDto
    {
        public int GPSModelID { get; set; }
        public int GNSSSystemID { get; set; }
    }
}
