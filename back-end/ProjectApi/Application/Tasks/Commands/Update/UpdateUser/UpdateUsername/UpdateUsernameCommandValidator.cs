using AppDomain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateUsername;

public class UpdateUsernameCommandValidator : AbstractValidator<UpdateUsernameCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUsernameCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UpdateUsernameCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();

        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull()
            .Must(BeUniqueUsername);
    }

    private bool BeUniqueUsername(string username)
    {
        var isUsernameExist = _userRepository.IsUsernameExistAsync(username).GetAwaiter().GetResult();

        return !isUsernameExist;
    }
}