using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.Model
{
    [Table("artists")]
    public class Artists
    {
        [Key]
        public Guid id { get; set; }

        [MaxLength(150), Required]
        public string name { get; set; } = string.Empty;

        public string? bio { get; set; }

        public string? imageUrl { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public ICollection<Albums> albums { get; set; } = new List<Albums>();
        public ICollection<Songs> songs { get; set; } = new List<Songs>();
    }
}