namespace Application.DTOs.User;
public class InsertUserDTO
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string? UserSecret { get; set; }
}