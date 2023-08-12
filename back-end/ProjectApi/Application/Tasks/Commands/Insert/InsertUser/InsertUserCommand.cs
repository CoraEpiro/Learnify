using AppDomain.DTO;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Insert.InsertUser;

public class InsertUserCommand : IRequest<string>
{
    public InsertPendingUserDTO User { get; set;}
}