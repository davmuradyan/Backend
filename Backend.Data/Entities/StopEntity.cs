using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
    }
}