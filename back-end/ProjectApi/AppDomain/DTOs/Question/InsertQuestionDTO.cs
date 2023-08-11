using AppDomain.Entities.TagBaseRelated;
using AppDomain.ValueObjects;

namespace AppDomain.DTO;

public class InsertQuestionDTO
{
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public IEnumerable<Category> CategoryList { get; set; }
}