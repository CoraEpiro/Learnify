using AppDomain.Common.Entities;

namespace AppDomain.Entities.ContentRelated;

public class Topic : EntityBase
{
    public string CourseId { get; set; }
    public string Name { get; set; }
}