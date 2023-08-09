namespace AppDomain.Entities.NotificationRelated;

public class CommentNotification : Notification
{
    public string ArticleId { get; set; } = String.Empty;
    public string? CommentId { get; set; }
}