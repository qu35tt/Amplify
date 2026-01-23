using System.ComponentModel.DataAnnotations;

namespace Amplify_backend.Model
{
    public class Artists
    {
        [Key]
        public Guid id { get; set; }

        [MaxLength(150), Required]
        public string name { get; set; }

        public string? Bio { get; set; }

        public string? AvatarUrl { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
