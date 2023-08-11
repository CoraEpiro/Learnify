using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUserByUsersecret;

public class GetUserByUsersecretCommandHandler : IRequestHandler<GetUserByUsersecretCommand, User>
{
    public IUserRepository _userRepository;

    public GetUserByUsersecretCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByUsersecretCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByUsernameAsync(request.Secret);
    }
}