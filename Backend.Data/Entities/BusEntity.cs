using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities {
    public class BusEntity {
        [Key]
        public int Bus_id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Model { get; set; }

        [Required]
        public int Capasity_standing { get; set; }

        [Required]
        public int Capasity_sitting {  get; set; }

        public int? Route_id { get; set; }

        [ForeignKey(nameof(Route_id))]
        public RouteEntity? Route { get; set; }

        [Required]
        [MaxLength(5)]
        public required string Bus_license_plate { get; set; }
    }
}