using Dapper;
using ProductMicroservice.Base;
using ProductMicroservice.Interfaces;
using ProductMicroservice.ProductAggregate;
using System.Data;

namespace ProductMicroservice.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task CreateAsync(Category category)
        {
            _dbConnection.Open();
            var query = "INSERT INTO Categories (Id, Name, Description)"
               + " VALUES (NewID(), @Name, @Description)";
            await _dbConnection.ExecuteScalarAsync<int>(query, category);
        }

        public async Task<bool> DeleteAsync(Category category)
        {
            _dbConnection.Open();
            var query = "DELETE FROM Categories WHERE Id = @Id";
            int affectedRows = await _dbConnection.ExecuteAsync(query, new { Id = category.Id });
            return affectedRows > 0;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            _dbConnection.Open();
            string query = "SELECT * FROM Categories";
            return await _dbConnection.QueryAsync<Category>(query);
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            _dbConnection.Open();
            string query = "SELECT * FROM Categories WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Category>(query, new { Id = id });
        }

        public async Task<bool> SoftDeleteAsync(Category category)
        {
            _dbConnection.Open();
            string query = "UPDATE Categories SET IsDeleted = @IsDeleted WHERE Id = @Id";
            int affectedRows = await _dbConnection.ExecuteAsync(query, category);
            return affectedRows > 0;
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            _dbConnection.Open();
            string query = "UPDATE Categories SET Name = @Name, Description = @Description WHERE Id = @Id";
            int affectedRows = await _dbConnection.ExecuteAsync(query, category);
            return affectedRows > 0;
        }
    }
}
