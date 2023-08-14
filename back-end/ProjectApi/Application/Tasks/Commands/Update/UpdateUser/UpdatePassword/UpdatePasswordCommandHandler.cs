using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdatePassword;

public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UpdatePasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.UpdatePasswordAsync(request.Id, request.Password);
    }
}