using ProductMicroservice.ProductAggregate;

namespace ProductMicroservice.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task<Category> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Category category);
        Task<bool> SoftDeleteAsync(Category category);
        Task<bool> DeleteAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
