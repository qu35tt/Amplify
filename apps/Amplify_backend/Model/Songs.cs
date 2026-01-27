using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    public enum StorageType
    {
        Local,
        Cloud
    }

    [Table("songs")]
    public class Songs
    {
        [Key]
        public Guid id { get; set; }

        [ForeignKey("Artist")]
        public Guid artistId { get; set; }

        [ForeignKey("Album")]
        public Guid albumId { get; set; }

        [MaxLength(100), Required]
        public string title { get; set; } = string.Empty;

        public int durationSeconds { get; set; }

        public int trackNumber { get; set; }

        [Required]
        public StorageType storageType { get; set; }

        [Required]
        public string filePath { get; set; } = string.Empty;

        [Required]
        public string fileExtension { get; set; } = string.Empty;

        public int bitrate { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public Artists? artist { get; set; }
        public Albums? album { get; set; }
        public ICollection<PlaylistSongs> playlists { get; set; } = new List<PlaylistSongs>();
    }
}