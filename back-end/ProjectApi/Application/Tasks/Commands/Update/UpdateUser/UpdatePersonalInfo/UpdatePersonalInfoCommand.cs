using AppDomain.Entities.UserRelated;
using AppDomain.Responses;
using MediatR;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdatePersonalInfo;

public class UpdatePersonalInfoCommand : IRequest<PersonalInfoResponse>
{
    public PersonalInfoResponse PersonalInfo { get; set; }
}