using AppDomain.Entities.TagBaseRelated;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.ArticleFlagQueries.GetArticleFlagById
{
    public class GetArticleFlagByIdQuery : IRequest<ArticleFlag>
    {
        public string ArticleFlagId { get; set; }
    }
}
