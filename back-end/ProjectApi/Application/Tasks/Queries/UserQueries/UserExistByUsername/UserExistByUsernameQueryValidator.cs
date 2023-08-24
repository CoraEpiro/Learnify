using AppDomain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.UserExistByUsername;

public class UserExistByUsernameQueryValidator : AbstractValidator<UserExistByUsernameQuery>
{
    public UserExistByUsernameQueryValidator()
    {
        RuleFor(q => q.Username).NotEmpty().NotNull();
    }
}
