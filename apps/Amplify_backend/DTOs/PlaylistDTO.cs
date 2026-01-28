using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amplify_backend.DTOs
{
    public class PlaylistDTO
    {
        public Guid id { get; set; }

        public Guid userId { get; set; }

        public string name { get; set; } = string.Empty;

        public string? description { get; set; }

        public string? coverImageUrl { get; set; }

        public bool isPublic { get; set; } = true;
    }
}
