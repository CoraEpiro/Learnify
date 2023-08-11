using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.GetUserByEmail;

public class GetUserByEmailCommandHandler : IRequestHandler<GetUserByEmailCommand, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByEmailAsync(request.Email);
    }
}