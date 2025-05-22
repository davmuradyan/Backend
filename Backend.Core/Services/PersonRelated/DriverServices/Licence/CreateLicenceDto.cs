namespace Backend.Core.Services.PersonRelated.DriverServices.Licence
{
    public record CreateLicenceDto
    {
        public int CountryID { get; set; }
        public string? IDNum { get; set; }
        public string? Category { get; set; }
    }
}
