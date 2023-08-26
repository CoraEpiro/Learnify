using AppDomain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateProfile;

public class UpdatePersonalInfoCommandValidator : AbstractValidator<UpdateUserProfileCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdatePersonalInfoCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public UpdatePersonalInfoCommandValidator()
    {
        RuleFor(x => x.UserProfile.Username)
            .Must(BeUniqueUsername);

        RuleFor(x => x.UserProfile.Email)
            .EmailAddress()
            .Must(BeUniqueEmail);
    }
    private bool BeUniqueUsername(string username)
    {
        var isUsernameExist = _userRepository.IsUsernameExistAsync(username).GetAwaiter().GetResult();

        return !isUsernameExist;
    }
    private bool BeUniqueEmail(string email)
    {
        var isEmailExist = _userRepository.IsEmailExistAsync(email).GetAwaiter().GetResult();

        return !isEmailExist;
    }
}