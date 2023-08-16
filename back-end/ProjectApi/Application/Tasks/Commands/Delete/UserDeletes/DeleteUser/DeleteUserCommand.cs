using AppDomain.DTO;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Delete.UserDeletes.DeleteUser;

public class DeleteUserCommand : IRequest<Task>
{
    public string Id { get; set; }
}