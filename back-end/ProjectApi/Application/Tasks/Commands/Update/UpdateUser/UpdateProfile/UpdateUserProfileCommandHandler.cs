using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using AppDomain.Responses;
using Application.DTO;
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
        return await _userRepository.UpdateProfileAsync(request.UserProfile);
    }
}