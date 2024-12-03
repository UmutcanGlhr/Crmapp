using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void DeleteOneProduct(Product product) => Remove(product);


        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductID.Equals(id), trackChanges);
        }

        public void UpdateOneProduct(Product entity) => Update(entity);
    }
}