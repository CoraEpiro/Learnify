using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertUser
{
    public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
    {
        public InsertUserCommandValidator()
        {
            RuleFor(u => u.User.Name).NotEmpty();
        }
    }
}
