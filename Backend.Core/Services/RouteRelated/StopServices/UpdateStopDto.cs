namespace Backend.Core.Services.RouteRelated.StopServices
{
    public record UpdateStopDto
    {
        public string? StopName { get; set; }
        public string? StopAddress { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public bool? IsTerminal { get; set; }
    }
}
