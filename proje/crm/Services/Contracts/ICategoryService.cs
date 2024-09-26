using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategory(bool trackChanges);
        void create(Category category);
    }
}