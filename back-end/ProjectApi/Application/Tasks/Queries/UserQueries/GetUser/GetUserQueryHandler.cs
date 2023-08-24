using AppDomain.DTOs.User;
using AppDomain.Interfaces;
using MediatR;

namespace Application.Tasks.Queries.UserQueries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserAuthDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserAuthDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.LogInAsync(request.Email, request.Password);
    }
}
