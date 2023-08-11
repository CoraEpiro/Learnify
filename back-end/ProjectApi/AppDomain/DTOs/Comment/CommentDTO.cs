using AppDomain.Entities.ContentRelated;

namespace AppDomain.DTO;

public class CommentDTO
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Body { get; set; } // Markdown
    public DateTime UpdateTime { get; set; }
    public VoteResponse Vote { get; set; }
    public IEnumerable<Comment>? CommentList { get; set; }
}