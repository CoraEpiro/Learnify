using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUserByUsersecret;

public class GetUserByUsersecretQueryHandler : IRequestHandler<GetUserByUsersecretQuery, User>
{
    public IUserRepository _userRepository;

    public GetUserByUsersecretQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByUsersecretQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.GetUserByUsernameAsync(request.Secret);
        }
        catch (Exception)
        {
            throw;
        }
    }
}