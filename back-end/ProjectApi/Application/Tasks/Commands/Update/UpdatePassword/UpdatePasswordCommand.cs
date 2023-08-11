using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdatePassword;

public class UpdatePasswordCommand : IRequest<User>
{
    public string Id { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
}