using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateCategory
{
    public class DecrementCategoryListUseCountCommandHandler : IRequestHandler<DecrementCategoryListUseCountCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DecrementCategoryListUseCountCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(DecrementCategoryListUseCountCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.DecrementUseCounts(request.CategoryIdList);

            return result;
        }
    }
}
