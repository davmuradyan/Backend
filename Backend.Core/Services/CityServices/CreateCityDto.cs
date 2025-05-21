namespace Backend.Core.Services.CityServices {
    public record CreateCityDto {
        public required string Name { get; set; }
        public int? Population { get; set; }
        public double? Area { get; set; }
        public int RegionID { get; set; }
    }
}