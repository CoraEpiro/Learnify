using AppDomain.Common.Entities;
using AppDomain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.UserRelated;

[Table("Users")]
public class PendingUser : EntityBase
{
    public string Name { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string Password { get; set; } = String.Empty;

    public string? UserSecret { get; set; }

    public DateTime JoinedTime { get; set; }

    public bool IsProfileBuilt { get; set; } = false;

    public bool IsDeleted { get; set; }

    public string RefreshToken { get; set; } = String.Empty;

    public UserRole Role { get; set; } = UserRole.Sapling;
}
