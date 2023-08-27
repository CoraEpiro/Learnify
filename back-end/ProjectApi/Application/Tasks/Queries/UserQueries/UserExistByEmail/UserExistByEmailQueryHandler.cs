using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.UserExistByEmail;

public class UserExistByEmailQueryHandler : IRequestHandler<UserExistByEmailQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public UserExistByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UserExistByEmailQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.IsEmailExistAsync(request.Email);
        }
        catch (Exception)
        {
            throw;
        }
    }
}