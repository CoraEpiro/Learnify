using AppDomain.Entities.ContentRelated;
using AppDomain.Entities.TagBaseRelated;
using AppDomain.Enums;
using AppDomain.ValueObjects;

namespace AppDomain.DTO;

public class QuestionDTO
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public IEnumerable<Category> CategoryList { get; set; }
    public DateTime UpdateTime { get; set; }
    public int ReadingTime { get; set; } // Minutes
    public int ViewCount { get; set; }
    public QuestionStatus Status { get; set; }
    public VoteResponse Vote { get; set; }
    public int WatchCount { get; set; }
    public IEnumerable<Answer> AnsweredList { get; set; }
    public Answer? CorrectAnswer { get; set; }
    public bool? IsViewed { get; set; }
    public bool? IsWatched { get; set; }
    public bool? IsSaved { get; set; }
}