using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.UserInserts.InserOTPCode;

using AppDomain.Entities.UserRelated;
using FluentValidation;
using System.Linq;

public class InsertOTPCommandValidator : AbstractValidator<InsertOTPCommand>
{
    public InsertOTPCommandValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

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