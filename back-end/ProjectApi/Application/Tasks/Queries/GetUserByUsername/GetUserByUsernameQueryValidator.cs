using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUserByUsername;

public class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
{
    public GetUserByUsernameQueryValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull();
    }
}