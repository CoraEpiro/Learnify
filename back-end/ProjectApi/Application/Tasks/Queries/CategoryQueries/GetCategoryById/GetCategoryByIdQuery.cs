using AppDomain.Entities.TagBaseRelated;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.CategoryQueries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public string CategoryId { get; set; }
    }
}
