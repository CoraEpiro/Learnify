using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUserByUsername;

public class GetUserByUsernameCommandValidator : AbstractValidator<GetUserByUsernameCommand>
{
    public GetUserByUsernameCommandValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull();
    }
}