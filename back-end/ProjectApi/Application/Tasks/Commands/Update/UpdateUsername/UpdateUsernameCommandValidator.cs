using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateUsername;

public class UpdateUsernameCommandValidator : AbstractValidator<UpdateUsernameCommand>
{
    public UpdateUsernameCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull();
    }
}