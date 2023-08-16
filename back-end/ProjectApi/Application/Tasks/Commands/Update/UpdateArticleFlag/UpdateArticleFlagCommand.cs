using AppDomain.DTOs.ArticleFlag;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateArticleFlag
{
    public class UpdateArticleFlagCommand : IRequest<string>
    {
        public UpdateArticleFlagDTO UpdateArticleFlagDTO { get; set; }
    }
}
