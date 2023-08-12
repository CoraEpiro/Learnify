using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.GetUser;

public class GetUserCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Repassword { get; set; }
}