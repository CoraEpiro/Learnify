using AppDomain.Entities.TagBaseRelated;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.ArticleFlagQueries.GetAllArticleFlag
{
    public class GetAllArticleFlagQuery : IRequest<List<ArticleFlag>>
    {

    }
}
