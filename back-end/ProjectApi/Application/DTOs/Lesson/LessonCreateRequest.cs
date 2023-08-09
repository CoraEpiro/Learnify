using AppDomain.ValueObjects;

public class LessonCreateRequest
{
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; } // Markdown
    public string? VideoLink { get; set; } // URL
}