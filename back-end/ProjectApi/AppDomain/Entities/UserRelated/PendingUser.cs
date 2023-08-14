using AppDomain.Common.Entities;

namespace AppDomain.Entities.UserRelated;

public class PendingUser : EntityBase
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string? UserSecret { get; set; }
    public DateTime JoinedTime { get; set; }
    public bool ProfileBuilded { get; set; } = false;
}