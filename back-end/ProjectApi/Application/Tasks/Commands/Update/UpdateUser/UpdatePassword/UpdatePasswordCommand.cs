using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdatePassword;

public class UpdatePasswordCommand : IRequest<User>
{
    public string NewPassword { get; set; }
}