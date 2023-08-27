using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.UserInserts.InserOTPCode;

using AppDomain.Entities.UserRelated;
using FluentValidation;
using System.Linq;

public class InsertOTPCommandValidator : AbstractValidator<InsertOTPCommand>
{
    public InsertOTPCommandValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}