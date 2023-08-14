using AppDomain.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.CategoryQueries.GetAllCategoryBuild
{
    public class GetAllCategoryBuildProfileQuery : IRequest<List<CategoryBuildProfileDTO>>
    {

    }
}
