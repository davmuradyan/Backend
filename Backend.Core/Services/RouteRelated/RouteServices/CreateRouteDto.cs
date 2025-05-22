namespace Backend.Core.Services.RouteRelated.RouteServices
{
    public record CreateRouteDto
    {
        public int RouteNum { get; set; }
        public required string StartHour { get; set; }
        public required string EndHour { get; set; }
    }
}
