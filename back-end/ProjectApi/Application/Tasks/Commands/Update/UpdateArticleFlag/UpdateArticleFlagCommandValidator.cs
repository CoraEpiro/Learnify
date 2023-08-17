using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateArticleFlag
{
    public class UpdateArticleFlagCommandValidator : AbstractValidator<UpdateArticleFlagCommand>
    {
        public UpdateArticleFlagCommandValidator()
        {
            RuleFor(x => x.UpdateArticleFlagDTO.Title).NotNull().NotEmpty();
        }
    }
}
