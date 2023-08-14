using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllCategory();

            return await Task.FromResult(result);
        }
    }
}
