using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    public class LikedSongs
    {
        public Guid UserId { get; set; }
        public Guid SongId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
        public Songs Song { get; set; }
    }
}

