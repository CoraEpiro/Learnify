using AppDomain.Interfaces;
using FluentValidation;

namespace Application.Tasks.Commands.Insert.InsertUser;

public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
{
    private readonly IUserRepository _userRepository;
    public InsertUserCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(dto => dto.User.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(dto => dto.User.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100)
            .Must(BeEmailUnique);

        RuleFor(dto => dto.User.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(16)
            .Matches("[A-Z]")
            .Matches("[a-z]")
            .Matches("[0-9]");
    }

    private bool BeEmailUnique(string email)
    {
        var isEmailExist = _userRepository.IsEmailExistAsync(email).GetAwaiter().GetResult();

        return !isEmailExist;
    }
}