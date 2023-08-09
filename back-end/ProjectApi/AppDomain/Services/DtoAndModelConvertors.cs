using AppDomain.Entities.UserRelated;

namespace AppDomain.Services;

public static class DtoAndModelConvertors
{
    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse
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
}