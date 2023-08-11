using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertUser;

public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
{
    public InsertUserCommandValidator()
    {
        RuleFor(dto => dto.User.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(dto => dto.User.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(dto => dto.User.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(16)
            .Matches("[A-Z]")
            .Matches("[a-z]")
            .Matches("[0-9]")
            .Must((dto, password) => !string.IsNullOrWhiteSpace(dto.User.UserSecret) || !string.IsNullOrWhiteSpace(password));

        RuleFor(dto => dto.User.UserSecret)
            .MaximumLength(100);
    }
}