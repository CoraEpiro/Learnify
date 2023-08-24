using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.UserExistByEmail;

public class UserExistByEmailQueryHandler : IRequestHandler<UserExistByEmailQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public UserExistByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(
        UserExistByEmailQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _userRepository.IsEmailExistAsync(request.Email);
    }
}
