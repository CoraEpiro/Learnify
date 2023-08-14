using FluentValidation;

namespace Application.Tasks.Queries.GetUserByEmail;

public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}