using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.UserExistByEmail;

public class UserExistByEmailQueryValidator : AbstractValidator<UserExistByEmailQuery>
{
    public UserExistByEmailQueryValidator()
    {
        RuleFor(q => q.Email).NotEmpty().NotNull().EmailAddress();
    }
}
