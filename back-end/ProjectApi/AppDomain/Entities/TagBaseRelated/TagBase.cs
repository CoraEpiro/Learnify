using AppDomain.Common.Entities;

namespace AppDomain.Entities.TagBaseRelated;

public class TagBase : EntityBase
{
    public string Title { get; set; } = String.Empty;
    public string? Description { get; set; }
    public int UseCount { get; set; }
    public string IconLink { get; set; } = String.Empty; // Link to the icon
    public string AccentColor { get; set; } = String.Empty; // Hex color
}