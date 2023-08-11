using AppDomain.Entities.TagBaseRelated;
using AppDomain.ValueObjects;

namespace AppDomain.DTO;

public class InsertArticleDTO
{
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public IEnumerable<Category> CategoryList { get; set; }
    public ArticleFlag Flag { get; set; }
}