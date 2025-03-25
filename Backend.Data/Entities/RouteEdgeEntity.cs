using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities {
    public class RouteEdgeEntity {
        [Key]
        public int RouteEdge_id { get; set; }

        [Required]
        public int Route_id {  get; set; }

        [ForeignKey(nameof(Route_id))]
        public RouteEntity? Route {  get; set; }

        [Required]
        public int Edge_id { get; set; }

        [ForeignKey(nameof(Edge_id))]
        public EdgeEntity? Edge { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
