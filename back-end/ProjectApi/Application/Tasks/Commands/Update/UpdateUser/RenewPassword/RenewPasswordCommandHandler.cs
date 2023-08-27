using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.RenewPassword;

public class RenewPasswordCommandHandler : IRequestHandler<RenewPasswordCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public RenewPasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Task> Handle(RenewPasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.RenewPasswordAsync(request.Email, request.NewPassword);
        }
        catch (Exception)
        {
            throw;
        }
    }
}