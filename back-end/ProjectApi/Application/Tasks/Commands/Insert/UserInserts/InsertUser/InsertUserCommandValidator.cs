using AppDomain.Interfaces;
using FluentValidation;

namespace Application.Tasks.Commands.Insert.UserInserts.InsertUser;

public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
{
    private readonly IUserRepository _userRepository;

    public InsertUserCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(dto => dto.User.Name).NotEmpty().MaximumLength(50);

        RuleFor(dto => dto.User.Email).NotEmpty().EmailAddress().MaximumLength(100);

        RuleFor(dto => dto.User.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(16)
            .Matches("[A-Z]")
            .Matches("[a-z]")
            .Matches("[0-9]");
    }
}
