namespace Backend.Data.Entities {
    public class RouteEdgeEntity {
        public int REID { get; set; }
        public int RouteID { get; set; }
        public int EdgeID { get; set; }
        public int Order { get; set; }
        public bool Direction { get; set; }

        public RouteEntity? Route { get; set; }
        public EdgeEntity? Edge { get; set; }
    }
}