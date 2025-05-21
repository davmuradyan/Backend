namespace Backend.Data.Entities {
    public class LicenceEntity {
        public int LicenceID { get; set; }
        public int CountryID { get; set; }
        public string? IDNum { get; set; }
        public string? Category { get; set; }

        public CountryEntity? Country { get; set; }
    }
}