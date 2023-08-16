using AppDomain.Entities.TagBaseRelated;
using AppDomain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class Post : Entry
{
    public ICollection<Category> Categories { get; set; }
    [Column(TypeName = "jsonb")]
    public Header Header { get; set; }
    public int ViewCount { get; set; }
    public int ReadingTime { get; set; } // Minute
}