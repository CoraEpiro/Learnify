using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.UserQueries.GetPendingUserById;

public class GetPendingUserByIdQueryValidator : AbstractValidator<GetPendingUserByIdQuery>
{
    public GetPendingUserByIdQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull();
    }
}