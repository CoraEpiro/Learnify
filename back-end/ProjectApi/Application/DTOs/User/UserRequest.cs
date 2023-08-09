namespace Application.DTOs.User;
public class UserRequest
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ProfilePhoto { get; set; }
    public IEnumerable<string>? CategoryFollowedList { get; set; } // Category Id List
}