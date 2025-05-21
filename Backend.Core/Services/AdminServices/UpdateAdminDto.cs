namespace Backend.Core {
    public record UpdateAdminDto {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? CityID { get; set; }
        public string? Type { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}