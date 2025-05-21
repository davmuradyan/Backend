namespace Backend.Data.Entities {
    public class GpsModelGNSSEntity {
        public int ID { get; set; }

        public int GPSModelID { get; set; }
        public GPSModelEntity? GPSModel { get; set; }

        public int GNSSSystemID { get; set; }
        public GNSSSystemEntity? GNSSSystem { get; set; }
    }
}