using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.ArticleFlagQueries.GetArticleFlagById
{
    public class GetArticleFlagByIdQueryHandler : IRequestHandler<GetArticleFlagByIdQuery, ArticleFlag>
    {
        private readonly IArticleFlagRepository _articleFlagRepository;

        public GetArticleFlagByIdQueryHandler(IArticleFlagRepository articleFlagRepository)
        {
            _articleFlagRepository = articleFlagRepository;
        }

        public async Task<ArticleFlag> Handle(GetArticleFlagByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _articleFlagRepository.GetArticleFlagById(request.ArticleFlagId);

            return result;
        }
    }
}
