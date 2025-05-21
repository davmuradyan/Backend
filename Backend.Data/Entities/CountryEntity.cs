namespace Backend.Data.Entities {
    public class CountryEntity {
        public int CountryID { get; set; }
        public required string Name { get; set; }
        public int? Population { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public ICollection<RegionEntity>? Regions { get; set; }
        public ICollection<ManufacturerEntity>? Manufacturers { get; set; }
        public ICollection<GNSSSystemEntity>? GNSSSystems { get; set; }
        public ICollection<LicenceEntity>? Licences { get; set; }
    }
}