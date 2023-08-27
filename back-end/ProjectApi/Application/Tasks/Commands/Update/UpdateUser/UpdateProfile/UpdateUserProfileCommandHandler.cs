using AppDomain.Interfaces;
using AppDomain.Responses;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateProfile;

public class UpdatePersonalInfoCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfile>
{
    private readonly IUserRepository _userRepository;

    public UpdatePersonalInfoCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserProfile> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.UpdateProfileAsync(request.UserProfile);
        }
        catch (Exception)
        {
            throw;
        }
    }
}