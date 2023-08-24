using AppDomain.DTO;
using AppDomain.DTOs.User;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Insert.UserInserts.InsertUser;

public class InsertUserCommand : IRequest<UserAuthDto>
{
    public InsertPendingUserDTO User { get; set; }
}
