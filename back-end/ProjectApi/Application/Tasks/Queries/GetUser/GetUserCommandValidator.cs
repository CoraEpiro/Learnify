using Application.Tasks.Queries.GetUserByEmail;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetUser;

public class GetUserCommandValidator : AbstractValidator<GetUserCommand>
{
    public GetUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .MaximumLength(16);

        RuleFor(u => u.Repassword)
            .NotEmpty()
            .NotNull()
            .Equal(u => u.Password);
    }
}