using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUser;

public class GetUserQuery : IRequest<UserAuthDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
