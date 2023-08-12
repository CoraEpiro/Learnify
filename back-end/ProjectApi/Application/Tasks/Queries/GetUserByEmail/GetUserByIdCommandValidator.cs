using Application.Tasks.Queries.GetUserById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUserByEmail;

public class GetUserByEmailCommandValidator : AbstractValidator<GetUserByEmailCommand>
{
    public GetUserByEmailCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}