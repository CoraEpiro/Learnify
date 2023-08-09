using AppDomain.Entities.ContentRelated;
using AppDomain.ValueObjects;

public class CourseResponse
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Description { get; set; }
    public string AccentColor { get; set; } // HEX
    public DateTime UpdateTime { get; set; }
    public IEnumerable<Topic> TopicList { get; set; }
    public int ViewCount { get; set; }
    public int FinishedCount { get; set; }
    public VoteResponse Vote { get; set; }
    public Progress Progress { get; set; }
    public bool IsFinished { get; set; }
}