using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.RenewPassword;

public class RenewPasswordCommand : IRequest<Task>
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}