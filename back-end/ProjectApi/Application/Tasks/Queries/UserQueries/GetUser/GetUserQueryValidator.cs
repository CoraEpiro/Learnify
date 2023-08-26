using AppDomain.Interfaces;
using FluentValidation;

namespace Application.Tasks.Queries.UserQueries.GetUser;

public class GetUserProfileQueryValidator : AbstractValidator<GetUserQuery>
{
    private readonly IUserRepository _userRepository;

    public GetUserProfileQueryValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public GetUserProfileQueryValidator()
    {
        RuleFor(u => u.Email).NotEmpty().NotNull().EmailAddress().Must(BeUniqueEmail);

        RuleFor(u => u.Password).NotEmpty().NotNull().MinimumLength(8).MaximumLength(16);
    }

    private bool BeUniqueEmail(string email)
    {
        var isEmailExist = _userRepository.IsEmailExistAsync(email).GetAwaiter().GetResult();

        return !isEmailExist;
    }
}
