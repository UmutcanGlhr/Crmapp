using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct(bool trackChanges);

        Product? GetOneProduct(int id, bool trackChanges);
        void CreateProduct(ProductDtoForInsertion productDto);

        void UpdateOneProduct(ProductDtoForUpdate productDto);

        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
        void DeleteOneProduct(int id);
    }
}