namespace Backend.Core.Services.VehicleRelated.ManufacturerServices
{
    public record CreateManufacturerDto
    {
        public required string Name { get; set; }
        public int CountryID { get; set; }
    }
}
