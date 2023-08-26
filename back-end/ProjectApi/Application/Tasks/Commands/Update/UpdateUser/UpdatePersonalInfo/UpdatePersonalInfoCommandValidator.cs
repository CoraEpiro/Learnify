using AppDomain.Interfaces;
using FluentValidation;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdatePersonalInfo;

public class UpdatePersonalInfoCommandValidator : AbstractValidator<UpdatePersonalInfoCommand>
{
    public UpdatePersonalInfoCommandValidator()
    {

    }
}