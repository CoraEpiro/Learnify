using System.Text.Json.Serialization;

namespace AppDomain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ConnectedAccountType
{
    GitHub,
    Twitter,
    Threads,
    YouTube
}
