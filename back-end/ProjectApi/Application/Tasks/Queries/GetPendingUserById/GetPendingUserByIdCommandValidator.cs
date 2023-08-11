using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetPendingUserById;

public class GetPendingUserByIdCommandValidator : AbstractValidator<GetPendingUserByIdCommand>
{
    public GetPendingUserByIdCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();
    }
}