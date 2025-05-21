namespace Backend.Data.Entities {
    public class StopEntity {
        public int StopID { get; set; }
        public string? StopName { get; set; }
        public string? StopAddress { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsTerminal { get; set; }
        public DateTime CreationDate { get; set; }
    }
}