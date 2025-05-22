namespace Backend.Core.Services.RouteRelated.RouteEdgeServices
{
    public record UpdateRouteEdgeDto
    {
        public int? RouteID { get; set; }
        public int? EdgeID { get; set; }
        public int? Order { get; set; }
        public bool? Direction { get; set; }
    }
}
