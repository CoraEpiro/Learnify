using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.UserInserts.BuildUser;

using AppDomain.Entities.UserRelated;
using FluentValidation;
using System.Linq;

public class BuildUserCommandValidator : AbstractValidator<BuildUserCommand>
{
    public BuildUserCommandValidator()
    {
        RuleFor(user => user.BuildUser.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

        RuleFor(user => user.BuildUser.ProfilePhoto)
            .NotEmpty().WithMessage("Profile photo is required.");
    }
}