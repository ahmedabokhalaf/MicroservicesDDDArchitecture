using ProductMicroservice.ProductAggregate;
using System.Linq.Expressions;

namespace ProductMicroservice.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task<Product> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Product product);
        Task<bool> SoftDeleteAsync(Product product);
        Task<bool> DeleteAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
