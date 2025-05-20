using System.Diagnostics.Metrics;

namespace Backend.Data.Entities {
    public class RegionEntity {
        public int RegionID { get; set; }
        public required string Name { get; set; }
        public int? Population { get; set; }
        public double? Area { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int CountryID { get; set; }
        public CountryEntity Country { get; set; }
    }
}
