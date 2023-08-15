using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
    {
        private readonly ICategoryRepository _repository;

        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Category category = _mapper.Map<Category>(request.updateCategoryDTO);

                var result = await _repository.UpdateCategory(category);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
      
        }
    }
}
