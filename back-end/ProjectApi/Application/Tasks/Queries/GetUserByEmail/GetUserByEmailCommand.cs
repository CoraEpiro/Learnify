using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.GetUserByEmail;

public class GetUserByEmailCommand : IRequest<User>
{
    public string Email { get; set;}
}