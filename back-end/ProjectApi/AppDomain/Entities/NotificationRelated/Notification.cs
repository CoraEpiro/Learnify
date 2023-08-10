using AppDomain.Common.Entities;
using AppDomain.Enums;

namespace AppDomain.Entities.NotificationRelated;
public class Notification : EntityBase
{
    public string Id { get; set; } = String.Empty;
    public string TriggerUserId { get; set; } = String.Empty;
    public NotificationType Type { get; set; }
}