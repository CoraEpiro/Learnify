using AppDomain.Interfaces;
using FluentValidation;

namespace Application.Tasks.Queries.GetUser;

public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /*    public GetUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .Must(BeUniqueEmail);

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(16);
        }
    */
    private bool BeUniqueEmail(string email)
    {
        var isEmailExist = _userRepository.IsEmailExistAsync(email).GetAwaiter().GetResult();

        return !isEmailExist;
    }
}