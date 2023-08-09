using AppDomain.Enums;

public class VoteResponse
{
    public int UpvoteCount { get; set; }
    public int DownvoteCount { get; set; }
    public VoteStatus Status { get; set; }
}