using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        return await _userRepository.GetUserByUsernameAsync(request.Username);
    }
}