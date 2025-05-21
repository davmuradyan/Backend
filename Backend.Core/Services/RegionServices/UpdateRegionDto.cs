namespace Backend.Core.Services.RegionServices {
    public record UpdateRegionDto {
        public string? Name { get; set; }
        public int? Population { get; set; }
        public double? Area { get; set; }
        public int? CountryID { get; set; }
    }
}
