using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using Application.Tasks.Commands.Insert.InsertUser;
using MediatR;

namespace Application.Tasks.Queries.GetPendingUserById;

public class GetPendingUserByIdCommandHandler : IRequestHandler<GetPendingUserByIdCommand, PendingUser>
{
    private readonly IUserRepository _userRepository;

    public GetPendingUserByIdCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PendingUser> Handle(GetPendingUserByIdCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetPendingUserByIdAsync(request.Id);
    }
}