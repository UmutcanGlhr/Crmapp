using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Product? GetOneProduct(int id, bool trackChanges);
    }
}