using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateCategory
{
    public class IncrementCategoryUseCountCommandHandler : IRequestHandler<IncrementCategoryUseCountCommand, int>
    {
        private readonly ICategoryRepository _repository;

        public IncrementCategoryUseCountCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(IncrementCategoryUseCountCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.IncrementUseCounts(request.CategoryIdList);

            return result;
        }
    }
}
