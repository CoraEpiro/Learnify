using AppDomain.Common.Entities;
using AppDomain.Enums;

namespace AppDomain.Entities.UserRelated;

public class ConnectedAccount : EntityBase
{
    public string Url { get; set; }
    public ConnectedAccountType Type { get; set; }
}