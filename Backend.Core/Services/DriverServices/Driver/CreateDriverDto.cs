namespace Backend.Core.Services.DriverServices.Driver
{
    public record CreateDriverDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? LicenceID { get; set; }
    }
}