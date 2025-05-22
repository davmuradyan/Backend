namespace Backend.Core.Services.VehicleRelated.VehicleServices
{
    public record CreateVehicleDto
    {
        public required string PlateNum { get; set; }
        public int VehicleTypeID { get; set; }
        public int? DriverID { get; set; }
        public int? GpsID { get; set; }
        public int CityID { get; set; }
        public int? RouteID { get; set; }
    }
}
