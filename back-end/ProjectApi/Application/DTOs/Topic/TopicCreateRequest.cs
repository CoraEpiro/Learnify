using AppDomain.Entities.ContentRelated;

public class TopicCreateRequest
{
    public string CourseId { get; set; }
    public IEnumerable<Lesson> LessonList { get; set; }
    public string Name { get; set; }
}