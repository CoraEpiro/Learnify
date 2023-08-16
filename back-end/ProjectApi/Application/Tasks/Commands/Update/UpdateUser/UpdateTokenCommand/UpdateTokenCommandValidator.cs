using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateUser.UpdateToken;

public class UpdateTokenCommandValidator : AbstractValidator<UpdateTokenCommand>
{
    public UpdateTokenCommandValidator()
    {

    }
}