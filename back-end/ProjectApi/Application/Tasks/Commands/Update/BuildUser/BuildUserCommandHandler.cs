﻿using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using Application.Tasks.Commands.Update.BuildUser;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdatePassword;

public class BuildUserCommandHandler : IRequestHandler<BuildUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public BuildUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(BuildUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.BuildUserAsync(request.BuildUser);
    }
}