using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Amplify_backend.Model
{
    public class PlaylistSongs
    {
        public Guid PlaylistId { get; set; }
        public Guid SongId { get; set; }

        public int Position { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public Playlists Playlist { get; set; }
        public Songs Song { get; set; }
    }
}

