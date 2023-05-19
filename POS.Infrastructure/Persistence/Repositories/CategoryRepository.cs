using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases;
using POS.Infrastructure.Persistence.Contexts;
using POS.Infrastructure.Persistence.Interfaces;

namespace POS.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly PosContext _context;

        public CategoryRepository(PosContext context)
        {
            _context = context;
        }

        public Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<Category> CategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> ListSelectCategories()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
         
    }
}
