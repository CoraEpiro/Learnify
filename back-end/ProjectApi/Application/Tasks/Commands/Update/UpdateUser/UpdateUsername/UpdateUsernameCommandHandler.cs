using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateUsername;

public class UpdateUsernameCommandHandler : IRequestHandler<UpdateUsernameCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UpdateUsernameCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.UpdateUsernameAsync(request.Id, request.Username);
        }
        catch (Exception)
        {
            throw;
        }
    }
}