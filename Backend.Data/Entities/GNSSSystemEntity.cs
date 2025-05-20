namespace Backend.Data.Entities {
    public record GNSSSystemEntity {
        public int GNSSSystemID { get; set; }
        public required string Name { get; set; }
        public string? FrequencyBand { get; set; }

        public int CountryID { get; set; }
        public CountryEntity Country { get; set; }

        public ICollection<GpsModelGNSS> GpsModelGNSS { get; set; }
    }
}