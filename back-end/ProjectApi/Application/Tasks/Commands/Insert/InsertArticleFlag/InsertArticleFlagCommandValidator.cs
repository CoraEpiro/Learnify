using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertArticleFlag
{
    public class InsertArticleFlagCommandValidator : AbstractValidator<InsertArticleFlagCommand>
    {
        public InsertArticleFlagCommandValidator()
        {
            RuleFor(x => x.ArticleFlagDTO.Title).NotEmpty().NotNull();
            RuleFor(x => x.ArticleFlagDTO.AccentColor).NotEmpty().NotNull();
            RuleFor(x => x.ArticleFlagDTO.Description).NotEmpty().NotNull();
            RuleFor(x => x.ArticleFlagDTO.IconLink).NotEmpty().NotNull();
        }
    }
}
