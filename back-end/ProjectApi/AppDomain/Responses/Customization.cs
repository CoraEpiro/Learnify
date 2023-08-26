using AppDomain.Entities.UserRelated;
using AppDomain.ValueObjects;

namespace AppDomain.Responses;

public class Customization
{
    public Settings Settings { get; set; }
    public Brand Brand { get; set; }
}