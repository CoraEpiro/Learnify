using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Commands.Delete.UserDeletes.DeleteUser;

public class DeleteUserCommand : IRequest<User>
{
    public string Id { get; set; }
}