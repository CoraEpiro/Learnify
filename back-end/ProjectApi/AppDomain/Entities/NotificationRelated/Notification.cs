using AppDomain.Common.Entities;
using AppDomain.Enums;

namespace AppDomain.Entities.NotificationRelated;
public class Notification : EntityBase
{
    public string Id { get; set; }
    public string TriggerUserId { get; set; }
    public NotificationType Type { get; set; }
}