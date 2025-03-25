using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Entities {
    public class RouteEntity {
        [Key]
        public int Route_id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
    }
}
