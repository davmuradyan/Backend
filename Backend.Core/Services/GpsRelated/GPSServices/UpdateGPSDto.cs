namespace Backend.Core.Services.GpsRelated.GPSServices
{
    public record UpdateGPSDto
    {
        public string? ID { get; set; }
        public int? GPSModelID { get; set; }
    }
}
