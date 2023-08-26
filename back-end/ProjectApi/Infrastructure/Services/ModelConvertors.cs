using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.ContentRelated;
using AppDomain.Entities.UserRelated;
using AppDomain.Responses;
using AppDomain.ValueObjects;
using Infrastructure.Persistence;

/// <summary>
/// Provides static methods to convert various entity types to their corresponding Data Transfer Objects (DTOs).
/// </summary>
public static class ModelConvertors
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

    /// <summary>
    /// Converts a <see cref="User"/> entity to a <see cref="UserResponse"/> Data Transfer Object,
    /// including additional information like answer counts.
    /// </summary>
    /// <param name="user">The <see cref="User"/> entity to convert.</param>
    /// <param name="answers">A collection of answers associated with the user.</param>
    /// <returns>The converted <see cref="UserResponse"/>.</returns>
    public static UserResponse ToUserResponse(this User user, UserResponsePublishedCounts counts)
    {
        return new UserResponse
        {
            Name = user.Name,
            DisplayEmail = user.Email,
            ProfilePhoto = user.ProfilePhoto,
            PersonalInfo = user.PersonalInfo,
            FollowedCategoryCount = user.CategoryFollowedList.Count(),
            PublishedArticlesCount = counts.PublishedArticlesCount,
            PublishedAnswerCount = counts.PublishedAnswerCount,
            PublishedQuestionCount = counts.PublishedQuestionCount,
            Brand = user.Brand,
            ConnectedAccountList = user.ConnectedAccountList,
            BadgeList = user.BadgeList,
            Grade = user.Grade,
            Joined = user.JoinedTime
        };
    }

    public static UserPreviewResponse ToUserPreviewResponse(this User user)
    {
        return new UserPreviewResponse
        {
            Name = user.Name,
            DisplayEmail = user.Email,
            ProfilePhoto = user.ProfilePhoto,
            Brand = user.Brand,
            Bio = user.PersonalInfo.Bio,
            Location = user.PersonalInfo.Location,
            Education = user.PersonalInfo.Education,
            Work = user.PersonalInfo.Work,
            Joined = user.JoinedTime
        };
    }
}