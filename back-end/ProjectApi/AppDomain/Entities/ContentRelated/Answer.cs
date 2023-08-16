using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class Answer : Entry
{
    public string QuestionId { get; set; }
    [Column(TypeName = "jsonb")]
    public Question Question { get; set; }
}