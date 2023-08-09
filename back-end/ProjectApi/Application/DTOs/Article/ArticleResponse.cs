using AppDomain.Entities.ContentRelated;
using AppDomain.Entities.TagBaseRelated;
using AppDomain.ValueObjects;

public class ArticleResponse
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public IEnumerable<Category> CategoryList { get; set; }
    public DateTime UpdateTime { get; set; }
    public int ReadingTime { get; set; } // Minutes
    public int ViewCount { get; set; }
    public Comment? Comment { get; set; }
    public ArticleFlag Flag { get; set; }
    public VoteResponse Vote { get; set; }
    public Answer? CorrectAnswer { get; set; }
    public bool IsSaved { get; set; }
}