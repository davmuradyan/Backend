namespace Backend.Core.Services.ManufacturerServices {
    public record CreateManufacturerDto {
        public required string Name { get; set; }
        public int CountryID { get; set; }
    }
}
