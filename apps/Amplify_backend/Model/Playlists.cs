using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    [Table("playlists")]
    public class Playlists
    {
        [Key]
        public Guid id { get; set; }

        [ForeignKey("User")]
        public Guid userId { get; set; }

        [MaxLength(100), Required]
        public string name { get; set; } = string.Empty;

        public string? description { get; set; }

        public string? coverImageUrl { get; set; }

        public bool isPublic { get; set; } = true;

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public Users? user { get; set; }
        public ICollection<PlaylistSongs> songs { get; set; } = new List<PlaylistSongs>();
    }
}