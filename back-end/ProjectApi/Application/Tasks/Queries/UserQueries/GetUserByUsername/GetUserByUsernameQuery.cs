using AppDomain.Entities.UserRelated;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUserByUsername;

public class GetUserByUsernameQuery : IRequest<User>
{
    public string Username { get; set; }
}