public class AnswerResponse
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public DateTime UpdateTime { get; set; }
    public string Body { get; set; } // Markdown
    public VoteResponse Vote { get; set; }
}