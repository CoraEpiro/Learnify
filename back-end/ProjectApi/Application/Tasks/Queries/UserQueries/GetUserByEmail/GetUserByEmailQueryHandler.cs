using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.GetUserByEmailAsync(request.Email);
        }
        catch (Exception)
        {
            throw;
        }
    }
}