using AppDomain.Common.Entities;
using AppDomain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class ContentBase : EntityBase
{
    public string UserId { get; set; } = String.Empty;
    public DateTime UpdateTime { get; set; }

    [Column(TypeName = "jsonb")]
    public Vote Vote { get; set; }
    public bool isDeleted { get; set; }
}