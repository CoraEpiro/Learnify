namespace AppDomain.Validations;

public class AuthenticationValidator : AbstractValidator<UserCreateRequest>
{
    public AuthenticationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(30)
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(16)
            .Matches("[A-Z]")
            .Matches("[a-z]")
            .Matches("[0-9]");
    }
}