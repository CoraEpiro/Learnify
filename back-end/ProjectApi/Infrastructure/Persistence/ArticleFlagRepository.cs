using AppDomain.Entities.TagBaseRelated;
using AppDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ArticleFlagRepository : IArticleFlagRepository
    {
        private readonly LearnifyDbContext _context;

        public ArticleFlagRepository(LearnifyDbContext context)
        {
            _context = context;
        }

        public Task<int> DecrementUseCounts(List<string> articleFlagIdList)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteArticleFlag(string id)
        {
            var existingArticleFLag = await _context.ArticleFlags.FindAsync(id);

            if (existingArticleFLag is null)
                return null;

            existingArticleFLag.isDeleted = true;

            _context.ArticleFlags.Update(existingArticleFLag);

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<List<ArticleFlag>> GetAllArticleFlag()
        {
            return _context.ArticleFlags.ToList();
        }

        public async Task<ArticleFlag> GetArticleFlagById(string id)
        {
            var existingArticleFlag = await _context.ArticleFlags.FindAsync(id);

            return existingArticleFlag;
        }

        public Task<int> IncrementUseCounts(List<string> articleFlagIdList)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertArticleFlag(ArticleFlag articleFlag)
        {
            var inserted = _context.ArticleFlags.Add(articleFlag);

            await _context.SaveChangesAsync();

            return inserted.Entity.Id;
        }

        public async Task<string> UpdateArticleFlag(ArticleFlag articleFlag)
        {
            var existingArticleFlag = await _context.ArticleFlags.FindAsync(articleFlag.Id);

            if (existingArticleFlag is null)
                return null;

            articleFlag.UseCount = existingArticleFlag.UseCount;

            _context.Entry(existingArticleFlag).CurrentValues.SetValues(articleFlag);

            await _context.SaveChangesAsync();

            return articleFlag.Id;
        }
    }
}
