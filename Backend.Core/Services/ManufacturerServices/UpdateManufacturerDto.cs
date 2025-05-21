namespace Backend.Core.Services.ManufacturerServices {
    public record UpdateManufacturerDto {
        public string? Name { get; set; }
        public int? CountryID { get; set; }
    }
}
