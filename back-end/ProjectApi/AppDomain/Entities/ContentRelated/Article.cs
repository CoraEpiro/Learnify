using AppDomain.Entities.TagBaseRelated;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class Article : Post
{
    [Column(TypeName = "jsonb")]
    public Comment? Comment { get; set; }
    [Column(TypeName = "jsonb")]
    public ArticleFlag Flag { get; set; }
}