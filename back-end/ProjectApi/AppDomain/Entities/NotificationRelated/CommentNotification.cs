namespace AppDomain.Entities.NotificationRelated;

public class CommentNotification : Notification
{
    public string ArticleId { get; set; }
    public string? CommentId { get; set; }
}