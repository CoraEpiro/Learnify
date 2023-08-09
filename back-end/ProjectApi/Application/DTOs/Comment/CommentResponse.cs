using AppDomain.Entities.ContentRelated;

public class CommentResponse
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Body { get; set; } // Markdown
    public DateTime UpdateTime { get; set; }
    public VoteResponse Vote { get; set; }
    public IEnumerable<Comment> CommentList { get; set; }
}