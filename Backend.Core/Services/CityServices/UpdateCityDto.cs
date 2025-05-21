namespace Backend.Core.Services.CityServices {
    public record UpdateCityDto {
        public string? Name { get; set; }
        public int? Population { get; set; }
        public double? Area { get; set; }
        public int? RegionID { get; set; }
    }
}