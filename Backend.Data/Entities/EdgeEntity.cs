using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities {
    public record EdgeEntity {
        [Key]
        public int Edge_id { get; set; }

        [Required]
        public int Start_stop_id { get; set; }

        [ForeignKey(nameof(Start_stop_id))]
        public StopEntity? Start_stop { get; set; }

        [Required]
        public int End_stop_id { get; set; }

        [ForeignKey(nameof(End_stop_id))]
        public StopEntity? End_stop { get; set; }

        [Required]
        public float Duration { get; set; }

        [Required]
        public float Distance { get; set; }

        public float AllowedSpeed { get; set; }
    }
}