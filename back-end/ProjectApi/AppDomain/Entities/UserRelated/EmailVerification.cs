using AppDomain.Common.Entities;

namespace AppDomain.Entities.UserRelated;

public class EmailVerification : EntityBase
{
    public string Email { get; set; } = String.Empty;
    public string OTP { get; set; } = String.Empty;
    public DateTime ExpireUntil { get; set; }
}