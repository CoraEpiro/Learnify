namespace AppDomain.Entities.NotificationRelated;

public class QuestionNotification : Notification
{
    public string QuestionId { get; set; } = String.Empty;
    public string? AnswerId { get; set; }
}