using Application.Tasks.Commands.Delete.UserDeletes.DeleteEmailVerification;
using FluentValidation;

namespace Application.Tasks.Commands.Delete.DeleteEmailVerification;

public class DeleteEmailVerificationCommandValidator : AbstractValidator<DeleteEmailVerificationCommand>
{
    public DeleteEmailVerificationCommandValidator()
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