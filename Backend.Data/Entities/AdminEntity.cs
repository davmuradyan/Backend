using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Entities {
    public class AdminEntity {
        [Key]
        public int Admin_id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public required string Email { get; set; }

        [Required]
        [StringLength(50)]
        public required string City { get; set; }

        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        [StringLength(50)]
        public required string Password { get; set; }
    }
}
