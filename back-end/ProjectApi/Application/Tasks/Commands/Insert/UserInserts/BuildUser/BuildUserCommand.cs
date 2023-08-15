using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Commands.Insert.UserInserts.BuildUser;

public class BuildUserCommand : IRequest<User>
{
    public BuildUserDTO BuildUser { get; set; }
}