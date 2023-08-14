using AppDomain.DTOs.Category;
using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.CategoryQueries.GetAllCategoryBuild
{
    public class GetAllCategoryBuildProfileQueryHandler : IRequestHandler<GetAllCategoryBuildProfileQuery, List<CategoryBuildProfileDTO>>
    {
        private readonly IMapper _mapper;

        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryBuildProfileQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryBuildProfileDTO>> Handle(GetAllCategoryBuildProfileQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllCategory();

            List<CategoryBuildProfileDTO> newList = _mapper.Map<List<CategoryBuildProfileDTO>>(result);

            return newList;
        }
    }
}
