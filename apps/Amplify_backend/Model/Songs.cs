using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    public class Songs
    {
        [Key]
        public Guid id { get; set; }

        [ForeignKey("Artists")]
        public Guid artistId { get; set; }
        [ForeignKey("Albums")]
        public Guid albumId { get; set; }
        [MaxLength(100), Required]
        public string title { get; set; }
        public int? duration_secs { get; set; }
        public int? track_number { get; set; }

        [Required]
        public storageType storage_Type { get; set; }

        [Required]
        public string file_path { get; set; }

        [Required]
        public string file_extension { get; set; }

        public int bitrate { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}

public enum storageType
{
        Local,
        Cloud
}
