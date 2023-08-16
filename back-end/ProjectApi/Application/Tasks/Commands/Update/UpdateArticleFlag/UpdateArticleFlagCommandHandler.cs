using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateArticleFlag
{
    public class UpdateArticleFlagCommandHandler : IRequestHandler<UpdateArticleFlagCommand,string>
    {
        private readonly IArticleFlagRepository _articleFlagRepository;

        private readonly IMapper _mapper;

        public UpdateArticleFlagCommandHandler(IArticleFlagRepository articleFlagRepository, IMapper mapper)
        {
            _articleFlagRepository = articleFlagRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateArticleFlagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArticleFlag articleFlag = _mapper.Map<ArticleFlag>(request.UpdateArticleFlagDTO);

                var result = await _articleFlagRepository.UpdateArticleFlag(articleFlag);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
