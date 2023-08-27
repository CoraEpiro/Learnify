using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateUser.RenewPassword;

public class RenewPasswordCommandValidator : AbstractValidator<RenewPasswordCommand>
{
    public RenewPasswordCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(u => u.NewPassword)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8) // Minimum length requirement
            .MaximumLength(16) // Maximum length requirement
            .Matches("[A-Z]") // At least one uppercase letter
            .Matches("[a-z]") // At least one lowercase letter
            .Matches("[0-9]") // At least one digit
            .Matches("[^a-zA-Z0-9]"); // At least one special character
    }
}