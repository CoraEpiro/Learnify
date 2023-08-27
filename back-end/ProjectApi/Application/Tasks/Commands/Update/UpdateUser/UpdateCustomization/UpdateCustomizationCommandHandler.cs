using AppDomain.DTO;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using AppDomain.Responses;
using Application.DTO;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateCustomization;

public class UpdateCustomizationCommandHandler : IRequestHandler<UpdateCustomizationCommand, Customization>
{
    private readonly IUserRepository _userRepository;

    public UpdateCustomizationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Customization> Handle(UpdateCustomizationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _userRepository.UpdateCustomizationAsync(request.Customization);
        }
        catch (Exception)
        {
            throw;
        }
    }
}