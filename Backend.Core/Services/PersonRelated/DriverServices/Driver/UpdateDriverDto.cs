namespace Backend.Core.Services.PersonRelated.DriverServices.Driver
{
    public record UpdateDriverDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? LicenceID { get; set; }
    }
}