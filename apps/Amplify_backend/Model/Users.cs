using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    [Table("users")]
    public class Users
    {
        [Key]
        public Guid id { get; set; }

        [MaxLength(254), Required]
        public string email { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? displayName { get; set; }

        public string? avatarUrl { get; set; }

        public bool isAdmin { get; set; } = false;

        [Required]
        public string password { get; set; } = string.Empty;

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public DateTime updatedAt { get; set; } = DateTime.UtcNow;

        // Navigation (No [Column] needed here)
        public ICollection<Playlists> Playlists { get; set; } = new List<Playlists>();
        public ICollection<LikedSongs> LikedSongs { get; set; } = new List<LikedSongs>();
    }
}