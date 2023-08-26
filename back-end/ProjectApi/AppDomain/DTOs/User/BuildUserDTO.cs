namespace AppDomain.DTOs.User;

public class BuildUserDTO
{
    public string Username { get; set; }
    public string ProfilePhoto { get; set; } // byte array
    public string Bio { get; set; }
    public string? WebsiteURL { get; set; }
    public string? Work { get; set; }
    public string? Education { get; set; }
    public IEnumerable<string>? CategoryFollowedList { get; set; } // Category Id List
}