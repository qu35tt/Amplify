using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    [Table("likedSongs")]
    public class LikedSongs
    {
        public Guid userId { get; set; }

        public Guid songId { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("userId")]
        public Users? user { get; set; }

        [ForeignKey("songId")]
        public Songs? song { get; set; }
    }
}

