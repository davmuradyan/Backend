namespace Backend.Data.Entities {
    public record DriverEntity {
        public int DriverID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? LicenceID { get; set; }
        public LicenceEntity? Licence { get; set; }
    }
}
