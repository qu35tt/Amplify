using System.ComponentModel.DataAnnotations;

public class UserUpdateData
{
    public string? email { get; set; }
    [MaxLength(150)]
    public string? display_name { get; set; }

    public string? AvatarUrl { get; set; }

    public bool? isAdmin { get; set; } = false;
    public string? password { get; set; }
}