using System.Text.Json.Serialization;

namespace AppDomain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QuestionStatus
{
    UnSolved,
    Solved,
    UnAnswered
}
