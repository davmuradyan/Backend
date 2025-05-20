namespace Backend.Core {
    public class CreateAdminDto {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public int CityID { get; set; }
        public required string Type { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}