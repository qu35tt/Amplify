using System.ComponentModel.DataAnnotations;

namespace Amplify_backend.Model
{
    public class User
    {
        [Key]
        public Guid id { get; set; }
        [MaxLength(254), Required]
        public string email { get; set; }
        [MaxLength(150)]
        public string display_name { get; set; }

        public string? AvatarUrl { get; set; }

        public bool isAdmin { get; set; } = false;

        [Required]
        public string password { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public DateTime updatedAt { get; set; } = DateTime.UtcNow;
    }
}
