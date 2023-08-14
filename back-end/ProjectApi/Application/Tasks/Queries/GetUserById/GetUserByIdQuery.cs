using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<User>
{
    public string Id { get; set; }
}