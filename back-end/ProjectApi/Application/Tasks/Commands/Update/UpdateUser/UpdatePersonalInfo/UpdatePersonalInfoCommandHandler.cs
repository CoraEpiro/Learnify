using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using AppDomain.Responses;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdatePersonalInfo;

public class UpdatePersonalInfoCommandHandler : IRequestHandler<UpdatePersonalInfoCommand, PersonalInfoResponse>
{
    private readonly IUserRepository _userRepository;

    public UpdatePersonalInfoCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PersonalInfoResponse> Handle(UpdatePersonalInfoCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.UpdatePersonalInfoAsync(request.PersonalInfo);
    }
}