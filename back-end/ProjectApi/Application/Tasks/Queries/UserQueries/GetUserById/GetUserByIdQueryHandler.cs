using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.GetUserByIdAsync(request.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}