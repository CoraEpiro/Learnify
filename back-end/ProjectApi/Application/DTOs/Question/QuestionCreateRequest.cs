using AppDomain.Entities.TagBaseRelated;
using AppDomain.ValueObjects;

public class QuestionCreateRequest
{
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public IEnumerable<Category> CategoryList { get; set; }
}