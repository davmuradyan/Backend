namespace Backend.Data.Entities {
    public class VehicleEntity {
        public int VehicleID { get; set; }
        public required string PlateNum { get; set; }
        public int VehicleTypeID { get; set; }
        public int? DriverID { get; set; }
        public int? GpsID { get; set; }
        public int CityID { get; set; }
        public int? RouteID { get; set; }

        public VehicleTypeEntity? VehicleType { get; set; }
        public DriverEntity? Driver { get; set; }
        public GPSEntity? GPS { get; set; }
        public CityEntity? City { get; set; }
        public RouteEntity? Route { get; set; }
    }
}