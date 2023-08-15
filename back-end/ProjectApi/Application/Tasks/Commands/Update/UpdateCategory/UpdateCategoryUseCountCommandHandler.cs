using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateCategory
{
    public class UpdateCategoryUseCountCommandHandler : IRequestHandler<UpdateCategoryUseCountCommand, int>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryUseCountCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateCategoryUseCountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.UpdateUseCount(request.CategoryId);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
