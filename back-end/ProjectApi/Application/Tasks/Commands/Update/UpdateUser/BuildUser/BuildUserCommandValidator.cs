using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateUser.BuildUser;

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

        // Add similar rules for other lists (ArticleSavedList, ArticleVoteList, etc.)

        // Add rules for PersonalInfo, Brand, Settings, ConnectedAccountList, BadgeList, Grade, etc.

        /*RuleFor(user => user.User.PersonalInfo)
            .SetValidator(new PersonalInfoValidator());

        RuleFor(user => user.User.Brand)
            .SetValidator(new BrandValidator());

        RuleFor(user => user.User.Settings)
            .SetValidator(new SettingsValidator());*/

        // ... More complex property validators

        // Example custom rule for validating a boolean property
    }
}