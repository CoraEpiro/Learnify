using AppDomain.DTOs.ArticleFlag;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertArticleFlag
{
    public class InsertArticleFlagCommand : IRequest<string>
    {
        public InsertArticleFlagDTO ArticleFlagDTO { get; set; }
    }
}
