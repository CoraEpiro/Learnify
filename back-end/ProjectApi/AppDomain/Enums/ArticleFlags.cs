using System.Text.Json.Serialization;

namespace AppDomain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ArticleFlags
{
    Solution,
    Guide,
    Advice,
    Comparison,
    Development,
    Update,
    Performance,
    Security
}
