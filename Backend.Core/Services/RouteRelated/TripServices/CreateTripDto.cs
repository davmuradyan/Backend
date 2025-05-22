namespace Backend.Core.Services.RouteRelated.TripServices
{
    public record CreateTripDto
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int VehicleID { get; set; }
        public int StartStopID { get; set; }
        public int EndStopID { get; set; }
        public int? EndStopWaitSecs { get; set; }
    }
}
