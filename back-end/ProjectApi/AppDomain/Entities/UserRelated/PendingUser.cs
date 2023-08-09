using AppDomain.Common.Entities;

namespace AppDomain.Entities.UserRelated;

public class PendingUser : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? UserSecret { get; set; }
    public DateTime CreatedTime { get; set; }
}