namespace Backend.Core.Services.GNSSSystemServices {
    public record CreateGNSSSystemDto {
        public required string Name { get; set; }
        public string? FrequencyBand { get; set; }
        public int CountryID { get; set; }
    }
}