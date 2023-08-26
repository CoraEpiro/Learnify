using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateCustomization;

public class UpdateCustomizationCommandValidator : AbstractValidator<UpdateCustomizationCommand>
{
    public UpdateCustomizationCommandValidator()
    {
        RuleFor(x => x.Customization.Brand.BannerPhoto)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Customization.Brand.AccentColor)
            .NotEmpty()
            .NotNull();
    }
}