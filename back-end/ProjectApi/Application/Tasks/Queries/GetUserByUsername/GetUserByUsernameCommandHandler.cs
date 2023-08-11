using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUserByUsername;

public class GetUserByUsernameCommandHandler : IRequestHandler<GetUserByUsernameCommand, User>
{
    public IUserRepository _userRepository;

    public GetUserByUsernameCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByUsernameCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByUsernameAsync(request.Username);
    }
}