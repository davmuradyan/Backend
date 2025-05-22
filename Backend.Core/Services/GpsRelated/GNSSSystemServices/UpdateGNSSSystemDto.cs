namespace Backend.Core.Services.GpsRelated.GNSSSystemServices
{
    public record UpdateGNSSSystemDto
    {
        public string? Name { get; set; }
        public string? FrequencyBand { get; set; }
        public int? CountryID { get; set; }
    }
}