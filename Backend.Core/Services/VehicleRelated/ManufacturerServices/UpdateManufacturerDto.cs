namespace Backend.Core.Services.VehicleRelated.ManufacturerServices
{
    public record UpdateManufacturerDto
    {
        public string? Name { get; set; }
        public int? CountryID { get; set; }
    }
}
