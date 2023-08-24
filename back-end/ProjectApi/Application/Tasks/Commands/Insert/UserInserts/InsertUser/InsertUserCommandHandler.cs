using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Insert.UserInserts.InsertUser;

public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, UserAuthDto>
{
    private readonly IUserRepository _userRepository;

    public InsertUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserAuthDto> Handle(
        InsertUserCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _userRepository.RegisterUserAsync(request.User);
    }
}
