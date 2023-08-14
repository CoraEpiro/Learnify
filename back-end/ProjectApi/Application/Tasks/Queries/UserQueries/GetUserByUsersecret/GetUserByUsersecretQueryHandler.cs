using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        return await _userRepository.GetUserByUsernameAsync(request.Secret);
    }
}