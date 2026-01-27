using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    [Table("albums")]
    public class Albums
    {
        [Key]
        public Guid id { get; set; }

        [ForeignKey("Artist")]
        public Guid artistId { get; set; }

        [MaxLength(80), Required]
        public string title { get; set; } = string.Empty;

        public string? coverArtUrl { get; set; }

        public DateOnly? releaseDate { get; set; }

        public string? genre { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public Artists? artist { get; set; }
        public ICollection<Songs> songs { get; set; } = new List<Songs>();
    }
}