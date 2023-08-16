using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using Application.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Insert.InsertArticleFlag
{
    public class InsertArticleFlagCommandHandler : IRequestHandler<InsertArticleFlagCommand,string>
    {
        private readonly IArticleFlagRepository _articleFlagRepository;

        private readonly IMapper _mapper;

        public InsertArticleFlagCommandHandler(IArticleFlagRepository articleFlagRepository, IMapper mapper)
        {
            _articleFlagRepository = articleFlagRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(InsertArticleFlagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArticleFlag articleFlag = _mapper.Map<ArticleFlag>(request.ArticleFlagDTO);

                articleFlag.Id = IDGeneratorService.GetShortUniqueId();

                articleFlag.UseCount = 0;

                var insertedId = await _articleFlagRepository.InsertArticleFlag(articleFlag);

                return insertedId;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
