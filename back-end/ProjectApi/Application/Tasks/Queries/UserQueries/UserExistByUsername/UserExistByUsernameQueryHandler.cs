using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.UserExistByUsername;

internal class UserExistByUsernameQueryHandler : IRequestHandler<UserExistByUsernameQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public UserExistByUsernameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UserExistByUsernameQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.IsUsernameExistAsync(request.Username);
        }
        catch (Exception)
        {
            throw;
        }
    }
}