namespace Backend.Core.Services.GpsRelated.GPSServices
{
    public record CreateGPSDto
    {
        public required string ID { get; set; }
        public int GPSModelID { get; set; }
    }
}
