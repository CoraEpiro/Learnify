using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.ArticleFlagQueries.GetAllArticleFlag
{
    public class GetAllArticleFlagQueryHandler : IRequestHandler<GetAllArticleFlagQuery, List<ArticleFlag>>
    {
        private readonly IArticleFlagRepository _repository;

        public GetAllArticleFlagQueryHandler(IArticleFlagRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ArticleFlag>> Handle(GetAllArticleFlagQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllArticleFlag();

            return result;
        }
    }
}
