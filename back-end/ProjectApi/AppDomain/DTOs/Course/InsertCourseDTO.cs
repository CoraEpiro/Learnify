using AppDomain.ValueObjects;

namespace AppDomain.DTO;

public class InsertCourseDTO
{
    public string UserId { get; set; }
    public Header Header { get; set; }
    public string Description { get; set; }
    public string AccentColor { get; set; } // HEX
}