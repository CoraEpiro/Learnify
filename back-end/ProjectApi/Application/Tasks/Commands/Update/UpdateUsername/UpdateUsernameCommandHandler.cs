using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUsername;

public class UpdateUsernameCommandHandler : IRequestHandler<UpdateUsernameCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UpdateUsernameCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.UpdateUsernameAsync(request.Id, request.Username);
    }
}