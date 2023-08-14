using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using Application.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertCategory
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public InsertCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Category category = _mapper.Map<Category>(request.categoryDTO);

                category.Id = IDGeneratorService.GetShortUniqueId();

                var result = await _categoryRepository.InsertCategory(category);

                return result;
            }
            catch (Exception)
            {

                throw;
            }        
        }
    }
}
