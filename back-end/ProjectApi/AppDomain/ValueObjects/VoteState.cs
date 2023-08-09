using AppDomain.Enums;

namespace AppDomain.ValueObjects;

public class VoteState
{
    public string ContentId { get; set; }
    public string? ChildId { get; set; }
    public VoteStatus VoteStatus { get; set; }
}