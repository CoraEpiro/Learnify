using FluentValidation;

namespace Application.Tasks.Commands.Delete.UserDeletes.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();
    }
}