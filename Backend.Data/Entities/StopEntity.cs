using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Entities {
    public record StopEntity {
        [Key]
        public int Stop_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        // Add navigation properties for the edges
        public ICollection<EdgeEntity> StartEdges { get; set; } = new List<EdgeEntity>();
        public ICollection<EdgeEntity> EndEdges { get; set; } = new List<EdgeEntity>();
    }
}
