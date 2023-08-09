using AppDomain.Entities.ContentRelated;

public class TopicResponse
{
    public string Id { get; set; }
    public string CourseId { get; set; }
    public IEnumerable<Lesson> LessonList { get; set; }
    public string Name { get; set; }
    public int CompletedPercentage { get; set; } // 0 -100
}