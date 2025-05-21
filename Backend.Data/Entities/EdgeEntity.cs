namespace Backend.Data.Entities {
    public class EdgeEntity {
        public int EdgeID { get; set; }
        public int StopA { get; set; }
        public int StopB { get; set; }
        public double? Distance { get; set; }
        public double? ExpectedTime { get; set; }
        public double? ExpectedSpeed { get; set; }

        public StopEntity? StopARef { get; set; }
        public StopEntity? StopBRef { get; set; }
    }
}