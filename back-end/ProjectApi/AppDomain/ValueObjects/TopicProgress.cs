using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.ValueObjects;

public class TopicProgress
{
    public string TopicId { get; set; }
    public int CompletedPercentage { get; set; } // Range: 0 - 100
    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? LessonList { get; set; } // Lesson Ids
}