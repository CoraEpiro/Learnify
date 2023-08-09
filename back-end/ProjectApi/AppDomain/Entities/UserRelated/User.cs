using System.ComponentModel.DataAnnotations.Schema;
using AppDomain.Common.Entities;
using AppDomain.Entities.NotificationRelated;
using AppDomain.ValueObjects;

namespace AppDomain.Entities.UserRelated;

public class User : EntityBase
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? UserSecret { get; set; }
    public string? Password { get; set; }
    public string ProfilePhoto { get; set; }
    [Column(TypeName = "jsonb")]
    public PersonalInfo PersonalInfo { get; set; }
    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? CategoryFollowedList { get; set; }
    [Column(TypeName = "jsonb")]
    public Brand Brand { get; set; }
    [Column(TypeName = "jsonb")]
    public Settings Settings { get; set; }
    public DateTime JoinedTime { get; set; }
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
    public IEnumerable<string>? QuestionSavedList { get; set; }
    [Column(TypeName = "jsonb")]
    public IEnumerable<string>? QuestionViewedList { get; set; }
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
    public string RefreshToken { get; set; }
    public bool ProfileBuilded { get; set; }
}