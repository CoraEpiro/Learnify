using AppDomain.Common.Entities;

namespace AppDomain.Entities.UserRelated;

public class EmailVerification : EntityBase
{
    public string Email { get; set; }
    public string OTP { get; set; }
    public DateTime ExpireUntil { get; set; }
}