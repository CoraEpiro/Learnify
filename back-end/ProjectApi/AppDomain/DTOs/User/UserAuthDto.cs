using AppDomain.Enums;

namespace AppDomain.DTOs.User;

public class UserAuthDto
{
    public UserAuthDto() { }

    public UserAuthDto(string token, UserRole role, string email, bool profileIsBuild)
    {
        Token = token;
        Role = role;
        Email = email;
        IsProfileBuilt = profileIsBuild;
    }

    public string Token { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public string Email { get; set; } = string.Empty;

    public bool IsProfileBuilt { get; set; }
}