using AppDomain.Entities.ContentRelated;
using AppDomain.ValueObjects;

public class LessonResponse
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public DateTime UpdateTime { get; set; }
    public int ReadingTime { get; set; } // Minutes
    public Comment? Comment { get; set; }
    public VoteResponse Vote { get; set; }
    public bool IsFinished { get; set; }
}