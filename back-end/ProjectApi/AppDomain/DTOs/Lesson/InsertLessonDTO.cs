using AppDomain.ValueObjects;

namespace AppDomain.DTO;

public class InsertLessonDTO
{
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public string? VideoLink { get; set; } // URL
}