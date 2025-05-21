namespace Backend.Data.Entities {
    public class GPSEntity {
        public int GpsID { get; set; }
        public required string ID { get; set; }

        public int GPSModelID { get; set; }
        public GPSModelEntity? GPSModel { get; set; }
    }
}