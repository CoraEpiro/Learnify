using AppDomain.ValueObjects;

namespace AppDomain.Responses;

public class UserPreviewResponse
{
    public string Name { get; set; }
    public string DisplayEmail { get; set; }
    public string ProfilePhoto { get; set; }
    public Brand Brand { get; set; }
    public string? Bio { get; set; }
    public string? Location { get; set; }
    public string? Education { get; set; }
    public string? Work { get; set; }
    public DateTime Joined { get; set; }
}