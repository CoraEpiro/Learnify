using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Queries.GetUserById;

public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByIdAsync(request.Id);
    }
}