using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.ValueObjects;

public class PersonalInfo
{
    public string? Bio { get; set; }
    public string? Work { get; set; }
    public string? Education { get; set; }
    public string? Location { get; set; }
    public string? DisplayEmail { get; set; }
    public string? WebsiteUrl { get; set; }
    [Column(TypeName = "jsonb")]
    public IEnumerable<PinnedRepository>? PinnedRepositories { get; set; }
    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? PinnedArticles { get; set; }
    public string? CurrentlyWorking { get; set; }
    public string? AvailableFor { get; set; }
}