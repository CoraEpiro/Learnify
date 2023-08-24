using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.UserExistByUsername;

internal class UserExistByUsernameQueryHandler : IRequestHandler<UserExistByUsernameQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public UserExistByUsernameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(
        UserExistByUsernameQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _userRepository.IsUsernameExistAsync(request.Username);
    }
}
