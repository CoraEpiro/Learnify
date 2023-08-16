using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Insert.UserInserts.InserOTPCode;

public class InsertOTPCommandHandler : IRequestHandler<InsertOTPCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public InsertOTPCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Task> Handle(InsertOTPCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.SendOTPCodeAsync(request.Email);
    }
}