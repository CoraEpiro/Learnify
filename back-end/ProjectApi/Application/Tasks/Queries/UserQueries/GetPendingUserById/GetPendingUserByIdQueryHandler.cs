using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using Application.Tasks.Commands.Insert.InsertUser;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetPendingUserById;

public class GetPendingUserByIdQueryHandler : IRequestHandler<GetPendingUserByIdQuery, PendingUser>
{
    private readonly IUserRepository _userRepository;

    public GetPendingUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PendingUser> Handle(GetPendingUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetPendingUserByIdAsync(request.Id);
    }
}