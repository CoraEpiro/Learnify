using AppDomain.DTOs.Category;
using AppDomain.Entities.TagBaseRelated;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertCategory
{
    public class InsertCategoryCommand : IRequest<string>
    {
        public InsertCategoryDTO categoryDTO { get;set; }
    }
}
