using AppDomain.Entities.ContentRelated;

namespace AppDomain.DTO;

public class InsertTopicDTO
{
    public string CourseId { get; set; }
    public IEnumerable<Lesson> LessonList { get; set; }
    public string Name { get; set; }
}