using AppDomain.Entities.TagBaseRelated;
using AppDomain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class Lesson : Entry
{
    [Column(TypeName = "jsonb")]
    public Header Header { get; set; }
    public int ReadingTime { get; set; } // Moment
    public string? VideoLink { get; set; } // Url
    [Column(TypeName = "jsonb")]
    public Comment? Comment { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Topic> Topics { get; set; }
}