using AppDomain.Entities;
using AppDomain.Entities.ContentRelated;

namespace AppDomain.DTO;

internal class TopicDTO
{
    public string Id { get; set; } = String.Empty;
    public string CourseId { get; set; } = String.Empty;
    public IEnumerable<Lesson> LessonList { get; set; }
    public string Name { get; set; } = String.Empty;
    public int CompletedPercentage { get; set; } // 0 -100
}