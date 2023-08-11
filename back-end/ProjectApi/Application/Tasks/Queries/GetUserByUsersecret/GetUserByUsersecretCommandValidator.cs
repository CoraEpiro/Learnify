using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUserByUsersecret;

public class GetUserByUsersecretCommandValidator : AbstractValidator<GetUserByUsersecretCommand>
{
    public GetUserByUsersecretCommandValidator()
    {
        RuleFor(u => u.Secret)
            .NotEmpty()
            .NotNull();
    }
}