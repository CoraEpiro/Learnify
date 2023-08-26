using AppDomain.Entities.UserRelated;
using AppDomain.Responses;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateProfile;

public class UpdateUserProfileCommand : IRequest<UserProfile>
{
    public UserProfile UserProfile { get; set; }
}