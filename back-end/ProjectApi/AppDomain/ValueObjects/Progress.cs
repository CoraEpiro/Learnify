namespace AppDomain.ValueObjects;

public class Progress
{
    public string CourseId { get; set; }
    public IEnumerable<TopicProgress>? TopicProgressList { get; set; }
    public int CompletedPercentage { get; set; } // Range: 0 - 100
}