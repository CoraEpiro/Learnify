using AppDomain.Entities.NotificationRelated;
using AppDomain.Entities.UserRelated;
using AppDomain.ValueObjects;

namespace AppDomain.DTO;

public class UserDTO
{
    public string Name { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty; // Hashed
    public string ProfilePhoto { get; set; } = String.Empty; // URL
    public PersonalInfo PersonalInfo { get; set; }
    public IEnumerable<string>? CategoryFollowedList { get; set; } // Category Id List
    public Brand Brand { get; set; }
    public Settings Settings { get; set; }
    public DateTime JoinedTime { get; set; }
    public IEnumerable<ConnectedAccount>? ConnectedAccountList { get; set; }
    public IEnumerable<Badge>? BadgeList { get; set; }
    public Grade Grade { get; set; }
    public IEnumerable<string>? ArticleViewedList { get; set; }
    public IEnumerable<string>? ArticleSavedList { get; set; }
    public IEnumerable<VoteState>? ArticleVoteList { get; set; }
    public IEnumerable<string>? QuestionSavedList { get; set; }
    public IEnumerable<string>? QuestionViewedList { get; set; }
    public IEnumerable<VoteState>? QuestionVoteList { get; set; }
    public IEnumerable<string>? WatchedQuestionList { get; set; }
    public IEnumerable<string>? ResourceSavedList { get; set; }
    public IEnumerable<VoteState>? ResourceVoteList { get; set; }
    public IEnumerable<Notification>? NotificationList { get; set; }
    public IEnumerable<string>? FinishedCourses { get; set; }
    public IEnumerable<Progress>? ProgressList { get; set; }
    public IEnumerable<VoteState>? CommentVoteList { get; set; }
}