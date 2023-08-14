using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUserByEmail;

public class GetUserByEmailQuery : IRequest<User>
{
    public string Email { get; set; }
}