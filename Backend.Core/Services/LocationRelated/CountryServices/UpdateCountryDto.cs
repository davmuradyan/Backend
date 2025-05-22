namespace Backend.Core.Services.LocationRelated.CountryServices
{
    public record UpdateCountryDto
    {
        public string? Name { get; set; }
        public int? Population { get; set; }
    }
}