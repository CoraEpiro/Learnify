using AppDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Delete.DeleteArticleFLag
{
    public class DeleteArticleFLagCommandHandler : IRequestHandler<DeleteArticleFLagCommand,string>
    {
        private readonly IArticleFlagRepository _articleFlagRepository;

        public DeleteArticleFLagCommandHandler(IArticleFlagRepository articleFlagRepository)
        {
            _articleFlagRepository = articleFlagRepository;
        }

        public async Task<string> Handle(DeleteArticleFLagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _articleFlagRepository.DeleteArticleFlag(request.ArticleFLagId);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
