namespace Amplify_backend.DTOs
{
    public class ArtistDTO
    {
        public Guid id { get; set; }
        public string? name { get; set; }

        public string? imageUrl { get; set; }
        public string? bio { get; set; }
    }
}
