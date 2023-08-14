using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertCategory
{
    public class InsertCategoryCommandValidator : AbstractValidator<InsertCategoryCommand>
    {
        public InsertCategoryCommandValidator() { 
            RuleFor(x => x.categoryDTO.AccentColor).NotEmpty();
            RuleFor(x => x.categoryDTO.IconLink).NotEmpty();
            RuleFor(x => x.categoryDTO.Title).NotEmpty();
            RuleFor(x => x.categoryDTO.Description).NotEmpty();
            
        }
    }
}
