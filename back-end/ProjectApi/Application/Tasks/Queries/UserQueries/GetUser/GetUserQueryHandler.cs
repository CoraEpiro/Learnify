using AppDomain.DTOs.User;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUser;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserQuery, UserAuthDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserProfileQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserAuthDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.LogInAsync(request.Email, request.Password);
    }
}
