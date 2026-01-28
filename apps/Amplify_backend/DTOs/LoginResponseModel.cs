using System.ComponentModel.DataAnnotations;

namespace Amplify_backend.DTOs
{
    public class LoginResponseModel
    {
        [Required]
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }
    }
}
