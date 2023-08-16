using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateToken;

public class UpdateTokenCommandHandler : IRequestHandler<UpdateTokenCommand, string>
{
    private readonly IUserRepository _userRepository;

    public UpdateTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.UpdateTokenAsync();
    }
}