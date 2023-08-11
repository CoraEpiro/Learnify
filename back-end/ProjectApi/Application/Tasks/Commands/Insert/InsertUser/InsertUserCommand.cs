using AppDomain.DTO;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Insert.InsertUser;

public class InsertUserCommand : IRequest<Task>
{
    public InsertPendingUserDTO User { get; set;}
}