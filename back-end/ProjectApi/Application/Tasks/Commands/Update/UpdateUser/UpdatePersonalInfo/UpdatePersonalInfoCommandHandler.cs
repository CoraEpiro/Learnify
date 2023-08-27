using AppDomain.Interfaces;
using AppDomain.Responses;
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
        try
        {
            return await _userRepository.UpdatePersonalInfoAsync(request.PersonalInfo);
        }
        catch (Exception)
        {
            throw;
        }
    }
}