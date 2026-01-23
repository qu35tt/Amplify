using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    public class Albums
    {
        [Key]
        public Guid id { get; set; }

        [ForeignKey("Artists")]
        public Guid artistId { get; set; }

        [MaxLength(80), Required]
        public char title { get; set; }

        public string? cover_art_url { get; set; }

        public DateOnly? release_date { get; set; }

        public string? genre { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
