using AppDomain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDomain.Entities.ContentRelated;

public class Question : Post
{
    public QuestionStatus Status { get; set; }
    public int WatchCount { get; set; }
    //public ICollection<Answer>? Answers { get; set; }

    [Column(TypeName = "jsonb")]
    public Answer? CorrectAnswer { get; set; }
}