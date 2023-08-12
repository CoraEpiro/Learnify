using AppDomain.DTO;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Insert.InsertUser;

public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, string>
{
    private readonly IUserRepository _userRepository;

    public InsertUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.RegisterUserAsync(request.User);
    }
}