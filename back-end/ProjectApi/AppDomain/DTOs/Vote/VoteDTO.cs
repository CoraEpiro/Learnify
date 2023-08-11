using AppDomain.Enums;

namespace AppDomain.DTO;

public class VoteDTO
{
    public int UpvoteCount { get; set; }
    public int DownvoteCount { get; set; }
    public VoteStatus Status { get; set; }
}