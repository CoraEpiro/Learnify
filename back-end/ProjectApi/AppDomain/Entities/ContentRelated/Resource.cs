using AppDomain.Entities.TagBaseRelated;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class Resource : ContentBase
{
    public string? Title { get; set; }
    public string? Url { get; set; }

    [Column(TypeName = "jsonb")]
    public Category Category { get; set; }

    [Column(TypeName = "jsonb")]
    public ResourceFlag Flag { get; set; }
}