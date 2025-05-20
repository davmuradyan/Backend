namespace Backend.Data.Entities {
    public record CityEntity {
        public int CityID { get; set; }
        public required string Name { get; set; }
        public int? Population { get; set; }
        public double? Area { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public int RegionID { get; set; }
        public RegionEntity Region { get; set; }
    }
}