using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities {
    public class DriverEntity {
        [Key]
        public int Driver_id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Surname { get; set; }

        public int? Bus_id { get; set; }

        [ForeignKey(nameof(Bus_id))]
        public BusEntity? Bus { get; set; }
    }
}
