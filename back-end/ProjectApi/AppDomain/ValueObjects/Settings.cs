using AppDomain.Enums;

namespace AppDomain.ValueObjects;

public class Settings
{
    public UiTheme Theme { get; set; }
    public UiFont Font { get; set; }
    public int ContentPerPage { get; set; }
    public bool IsTwoFactorActivated { get; set; }
}