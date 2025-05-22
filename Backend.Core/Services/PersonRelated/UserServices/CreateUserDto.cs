namespace Backend.Core.Services.PersonRelated.UserServices
{
    public record CreateUserDto
    {
        public required string IP { get; set; }
        public DateTime ConnectionTime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime? DisconnectionTime { get; set; }
        public int? CityID { get; set; }
    }
}
