using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.GetPendingUserById;

public class GetPendingUserByIdCommand : IRequest<PendingUser>
{
    public string Id { get; set;}
}