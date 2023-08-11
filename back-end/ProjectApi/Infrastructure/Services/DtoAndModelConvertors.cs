using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;

namespace Infrastructure.Services;

public static class DtoAndModelConvertors
{
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