namespace Application.DTO;
public class InsertPendingUserDTO
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string? UserSecret { get; set; }
}