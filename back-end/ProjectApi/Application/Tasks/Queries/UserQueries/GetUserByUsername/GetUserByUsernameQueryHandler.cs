using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUserByUsername;

public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, User>
{
    public IUserRepository _userRepository;

    public GetUserByUsernameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.GetUserByUsernameAsync(request.Username);
        }
        catch (Exception)
        {
            throw;
        }
    }
}