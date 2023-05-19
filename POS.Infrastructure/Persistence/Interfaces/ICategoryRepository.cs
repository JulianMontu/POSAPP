using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases;

namespace POS.Infrastructure.Persistence.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<Category> CategoryById(int categoryId);
        Task<bool> RegisterCategory(Category category);
        Task<bool> EditCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
}
