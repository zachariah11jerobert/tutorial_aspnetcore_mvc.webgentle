using BookStore.Data;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class LanguageRepository
    {

        private readonly BookStoreDbContext _bookStoreDbContext = null;
        public LanguageRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _bookStoreDbContext.Languages.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
