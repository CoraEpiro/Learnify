using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;

/// <summary>
/// Provides extension methods for converting between entity models and Data Transfer Objects (DTOs).
/// </summary>
public static class DtoAndModelConvertors
{
    /// <summary>
    /// Converts a <see cref="User"/> entity to a <see cref="UserDTO"/> Data Transfer Object.
    /// </summary>
    /// <param name="user">The <see cref="User"/> entity to convert.</param>
    /// <returns>The converted <see cref="UserDTO"/>.</returns>
    public static UserDTO ToUserDTO(this User user)
    {
        return new UserDTO
        {
            UserName = user.UserName,
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            ProfilePhoto = user.ProfilePhoto,
            PersonalInfo = user.PersonalInfo,
            CategoryFollowedList = user.CategoryFollowedList,
            Brand = user.Brand,
            Settings = user.Settings,
            JoinedTime = user.JoinedTime,
            ConnectedAccountList = user.ConnectedAccountList,
            BadgeList = user.BadgeList,
            Grade = user.Grade,
            ArticleViewedList = user.ArticleViewedList,
            ArticleSavedList = user.ArticleSavedList,
            ArticleVoteList = user.ArticleVoteList,
            QuestionSavedList = user.QuestionSavedList,
            QuestionViewedList = user.QuestionViewedList,
            QuestionVoteList = user.QuestionVoteList,
            WatchedQuestionList = user.WatchedQuestionList,
            ResourceSavedList = user.ResourceSavedList,
            ResourceVoteList = user.ResourceVoteList,
            NotificationList = user.NotificationList,
            FinishedCourses = user.FinishedCourses,
            ProgressList = user.ProgressList,
            CommentVoteList = user.CommentVoteList
        };
    }

    /// <summary>
    /// Converts a <see cref="PendingUser"/> entity to a <see cref="PendingUserDTO"/> Data Transfer Object.
    /// </summary>
    /// <param name="user">The <see cref="PendingUser"/> entity to convert.</param>
    /// <returns>The converted <see cref="PendingUserDTO"/>.</returns>
    public static PendingUserDTO ToPendingUserDTO(this PendingUser user)
    {
        return new PendingUserDTO
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            JoinedTime = user.JoinedTime
        };
    }
}