namespace AppDomain.Entities.NotificationRelated;

public class QuestionNotification : Notification
{
    public string QuestionId { get; set; }
    public string? AnswerId { get; set; }
}