namespace Backend.Core.Services.RouteRelated.EdgeServices
{
    public record CreateEdgeDto
    {
        public int StopA { get; set; }
        public int StopB { get; set; }
        public double? Distance { get; set; }
        public double? ExpectedTime { get; set; }
        public double? ExpectedSpeed { get; set; }
    }
}
