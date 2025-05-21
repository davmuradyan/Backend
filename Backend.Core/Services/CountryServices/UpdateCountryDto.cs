namespace Backend.Core.Services.CountryServices {
    public record UpdateCountryDto {
        public string? Name { get; set; }
        public int? Population { get; set; }
    }
}