using AppDomain.DTO;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Insert.UserInserts.InsertUser;

public class InsertUserCommand : IRequest<string>
{
    public InsertPendingUserDTO User { get; set; }
}