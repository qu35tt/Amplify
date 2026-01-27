using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Amplify_backend.Model
{
    [Table("playlistSongs")]
    public class PlaylistSongs
    {
        public Guid playlistId { get; set; }

        public Guid songId { get; set; }

        public int position { get; set; }

        public DateTime addedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("PlaylistId")]
        public Playlists? playlist { get; set; }

        [ForeignKey("SongId")]
        public Songs? song { get; set; }
    }
}

