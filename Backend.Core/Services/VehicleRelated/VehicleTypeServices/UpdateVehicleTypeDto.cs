namespace Backend.Core.Services.VehicleRelated.VehicleTypeServices
{
    public record UpdateVehicleTypeDto
    {
        public string? Model { get; set; }
        public int? Sits { get; set; }
        public int? MaxCapacity { get; set; }
        public bool? IsElectric { get; set; }
        public int? ManufacturerID { get; set; }
    }
}
