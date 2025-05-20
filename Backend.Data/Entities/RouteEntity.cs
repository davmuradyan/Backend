namespace Backend.Data.Entities {
    public record RouteEntity {
        public int RouteID { get; set; }
        public int RouteNum { get; set; }
        public required string StartHour { get; set; }
        public required string EndHour { get; set; }
        public ICollection<RouteEdgeEntity> RouteEdges { get; set; } = new List<RouteEdgeEntity>();
        public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
    }
}