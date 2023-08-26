using System.ComponentModel.DataAnnotations.Schema;
using AppDomain.Entities.NotificationRelated;
using AppDomain.ValueObjects;
using AppDomain.DTOs.User;

namespace AppDomain.Entities.UserRelated;

public class User : PendingUser
{
    // Name is in PendingUser
    // Email is in PendingUser
    // Password is in PendingUser
    // UserSecret is in PendingUser
    // JoinedTime is in PendingUser
    public User() { }
    public User(PendingUser pendingUser)
    {
        Name = pendingUser.Name;
        Email = pendingUser.Email;
        Password = pendingUser.Password;
        UserSecret = pendingUser.UserSecret;
        JoinedTime = pendingUser.JoinedTime;
    }
    public void BuildUser(BuildUserDTO buildUser)
    {
        UserName = buildUser.Username;
        ProfilePhoto = buildUser.ProfilePhoto;
        PersonalInfo = new PersonalInfo();
        PersonalInfo.Bio = buildUser.Bio;
        PersonalInfo.WebsiteUrl = buildUser.WebsiteURL;
        PersonalInfo.Work = buildUser.Work;
        PersonalInfo.Education = buildUser.Education;
        CategoryFollowedList = buildUser.CategoryFollowedList;
    }
    public string UserName { get; set; } = String.Empty;
    public string ProfilePhoto { get; set; } = String.Empty;

    [Column(TypeName = "jsonb")]
    public PersonalInfo PersonalInfo { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? CategoryFollowedList { get; set; }

    [Column(TypeName = "jsonb")]
    public Brand Brand { get; set; }

    [Column(TypeName = "jsonb")]
    public Settings Settings { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<ConnectedAccount>? ConnectedAccountList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<Badge>? BadgeList { get; set; }

    [Column(TypeName = "jsonb")]
    public Grade? Grade { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<Notification>? NotificationList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? ArticleViewedList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? ArticleSavedList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<VoteState>? ArticleVoteList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? QuestionViewedList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? QuestionSavedList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<VoteState>? QuestionVoteList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? WatchedQuestionList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? ResourceSavedList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<VoteState>? ResourceVoteList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? FinishedCourses { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<Progress>? ProgressList { get; set; }

    [Column(TypeName = "jsonb")]
    public IEnumerable<VoteState>? CommentVoteList { get; set; }
}