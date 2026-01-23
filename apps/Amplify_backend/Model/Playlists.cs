using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    public class Playlists
    {
        [Key]
        public Guid id { get; set; }

        [ForeignKey("User")]
        public Guid userId { get; set; }

        [MaxLength(100)]
        public string name { get; set; }

        public string? description { get; set; }

        public string? cover_image_url { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
