using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdatePassword;

public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8) // Minimum length requirement
            .MaximumLength(16) // Maximum length requirement
            .Matches("[A-Z]") // At least one uppercase letter
            .Matches("[a-z]") // At least one lowercase letter
            .Matches("[0-9]") // At least one digit
            .Matches("[^a-zA-Z0-9]"); // At least one special character

        RuleFor(u => u.Password == u.RePassword);
    }
}