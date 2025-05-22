namespace Backend.Core.Services.LocationRelated.RegionServices
{
    public record CreateRegionDto
    {
        public required string Name { get; set; }
        public int? Population { get; set; }
        public double? Area { get; set; }
        public int CountryID { get; set; }
    }
}
