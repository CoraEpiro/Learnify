using AppDomain.Entities.UserRelated;
using AppDomain.Responses;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateCustomization;

public class UpdateCustomizationCommand : IRequest<Customization>
{
    public Customization Customization { get; set; }
}