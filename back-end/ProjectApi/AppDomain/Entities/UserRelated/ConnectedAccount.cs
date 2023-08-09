using AppDomain.Common.Entities;
using AppDomain.Enums;

namespace AppDomain.Entities.UserRelated;

public class ConnectedAccount : EntityBase
{
    public string Url { get; set; } = String.Empty;
    public ConnectedAccountType Type { get; set; }
}