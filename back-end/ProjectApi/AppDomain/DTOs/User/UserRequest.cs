namespace AppDomain.DTO;

public class UserRequest
{
    public string Username { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string ProfilePhoto { get; set; } = String.Empty;
    public IEnumerable<string>? CategoryFollowedList { get; set; } // Category Id List
}