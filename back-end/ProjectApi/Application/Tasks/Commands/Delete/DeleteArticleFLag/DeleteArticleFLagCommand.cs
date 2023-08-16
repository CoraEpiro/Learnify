using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Delete.DeleteArticleFLag
{
    public class DeleteArticleFLagCommand : IRequest<string>
    {
        public string ArticleFLagId { get; set; }
    }
}
