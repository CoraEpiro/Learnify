using AppDomain.Entities.UserRelated;
using AppDomain.ValueObjects;

namespace AppDomain.Responses;

public class UserResponse
{
    public string Name { get; set; }
    public string DisplayEmail { get; set; }
    public string ProfilePhoto { get; set; }
    public PersonalInfo PersonalInfo { get; set; }
    public int FollowedCategoryCount { get; set; }
    public int PublishedArticlesCount { get; set; }
    public int PublishedQuestionCount { get; set; }
    public int PublishedAnswerCount { get; set; }
    public Brand Brand { get; set; }
    public IEnumerable<ConnectedAccount>? ConnectedAccountList { get; set; }
    public IEnumerable<Badge>? BadgeList { get; set; }
    public Grade Grade { get; set; }
    public DateTime Joined { get; set; }
}