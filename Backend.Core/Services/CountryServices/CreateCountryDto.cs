namespace Backend.Core.Services.CountryServices {
    public record CreateCountryDto {
        public required string Name { get; set; }
        public int? Population { get; set; }
    }
}