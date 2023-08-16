using Application.Tasks.Commands.Delete.UserDeletes.VerifyEmail;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Delete.VerifyEmail;

public class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
{
    public VerifyEmailCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(u => u.OTP)
            .NotEmpty()
            .NotNull();
    }
}