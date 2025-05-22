namespace Backend.Core.Services.RouteRelated.RouteServices
{
    public record UpdateRouteDto
    {
        public int? RouteNum { get; set; }
        public string? StartHour { get; set; }
        public string? EndHour { get; set; }
    }
}
