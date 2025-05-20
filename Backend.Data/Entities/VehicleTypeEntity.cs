namespace Backend.Data.Entities {
    public record VehicleTypeEntity {
        public int VehicleTypeID { get; set; }
        public required string Model { get; set; }
        public int Sits { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsElectric { get; set; }

        public int ManufacturerID { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; }
    }
}