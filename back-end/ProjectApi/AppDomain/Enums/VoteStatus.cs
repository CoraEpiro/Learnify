using System.Text.Json.Serialization;

namespace AppDomain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VoteStatus
{
    UnVote,
    UpVote,
    DownVote
}
