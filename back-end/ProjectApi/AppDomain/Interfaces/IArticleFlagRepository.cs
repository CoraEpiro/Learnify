using AppDomain.Entities.TagBaseRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Interfaces
{
    public interface IArticleFlagRepository
    {
        Task<List<ArticleFlag>> GetAllArticleFlag();
        Task<ArticleFlag> GetArticleFlagById(string id);
        Task<string> InsertArticleFlag(ArticleFlag articleFlag);
        Task<string> UpdateArticleFlag(ArticleFlag articleFlag);
        Task<string> DeleteArticleFlag(string id);
        Task<int> IncrementUseCounts(List<string> articleFlagIdList);
        Task<int> DecrementUseCounts(List<string> articleFlagIdList);
    }
}
