using Application.Tasks.Commands.Delete.UserDeletes.DeleteEmailVerification;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Delete.DeleteEmailVerification;

public class DeleteEmailVerificationValidator : AbstractValidator<DeleteEmailVerificationCommand>
{
    public DeleteEmailVerificationValidator()
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