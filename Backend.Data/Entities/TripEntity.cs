namespace Backend.Data.Entities {
    public class TripEntity {
        public int TripID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int VehicleID { get; set; }
        public int StartStopID { get; set; }
        public int EndStopID { get; set; }
        public int? EndStopWaitSecs { get; set; }

        public VehicleEntity? Vehicle { get; set; }
        public StopEntity? StartStop { get; set; }
        public StopEntity? EndStop { get; set; }
    }
}