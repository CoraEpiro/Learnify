using AppDomain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class Course : ContentBase
{
    [Column(TypeName = "jsonb")]
    public Header Header { get; set; }
    public string Description { get; set; }
    public string AccentColor { get; set; } // HEXs
    public IEnumerable<Topic> TopicList { get; set; }
    public int ViewCount { get; set; }
    public int FinishedCount { get; set; }
}