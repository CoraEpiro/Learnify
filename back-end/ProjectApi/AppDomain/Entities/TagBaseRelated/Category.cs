using AppDomain.Entities.ContentRelated;

namespace AppDomain.Entities.TagBaseRelated;

public class Category : TagBase
{
    //public bool IsFollowed { get; set; }
    public IEnumerable<Article> Articles { get; set; }
    public IEnumerable<Question> Questions { get; set; }
    public IEnumerable<Lesson> Lessons { get; set; }
}