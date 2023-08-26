using AppDomain.Entities.UserRelated;
using AppDomain.ValueObjects;

namespace AppDomain.Responses;

public class Customization
{
    public PersonalInfo PersonalInfo { get; set; }
    public IEnumerable<ConnectedAccount> ConnectedAccountList { get; set; }
}