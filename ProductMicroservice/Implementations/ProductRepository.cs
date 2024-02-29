using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Base;
using ProductMicroservice.Database;
using ProductMicroservice.Interfaces;
using ProductMicroservice.ProductAggregate;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace ProductMicroservice.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task CreateAsync(Product product)
        {
            _dbConnection.Open();
            var query = "INSERT INTO Products (Id, Name, Description, Price, CategoryId, IsDeleted)"
               +" VALUES (NewID(), @Name, @Description, @Price, @CategoryId, @IsDeleted)";
            await _dbConnection.ExecuteScalarAsync<int>(query, product);
        }
        public async Task<bool> DeleteAsync(Product product)
        {
            _dbConnection.Open();
            var query = "DELETE FROM Products WHERE Id = @Id";
            int affectedRows = await _dbConnection.ExecuteAsync(query, new { Id = product.Id });
            return affectedRows > 0;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            _dbConnection.Open();
            string query = "SELECT * FROM Products";
            return await _dbConnection.QueryAsync<Product>(query);
        }
        public async Task<Product> GetByIdAsync(Guid id)
        {
            _dbConnection.Open();
            string query = "SELECT * FROM Products WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }
        public async Task<bool> SoftDeleteAsync(Product product)
        {
            _dbConnection.Open();
            string query = "UPDATE Products SET IsDeleted = @IsDeleted WHERE Id = @Id";
            int affectedRows = await _dbConnection.ExecuteAsync(query, product);
            return affectedRows > 0;
            //await product.SoftDelete();
            //_context.Products.Update(product);
        }
        public async Task<bool> UpdateAsync(Product product)
        {
            _dbConnection.Open();
            string query = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, CategoryId = @CategoryId WHERE Id = @Id";
            int affectedRows = await _dbConnection.ExecuteAsync(query, product);
            return affectedRows > 0;
            //_context.Products.Update(product);
        }
        //public async Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<Product> query = _context.Set<Product>();
        //    if (includes != null)
        //        foreach (var include in includes)
        //            query = query.Include(include);
        //    query = query.Where(x => !x.IsDeleted);
        //    query = query.OrderByDescending(x => x.Name);
        //    return await query.Where(criteria).ToListAsync();
        //}

        //public async Task<Product> FindAsync(Expression<Func<Product, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<Product> query = _context.Products;
        //    if (includes != null)
        //        foreach (var include in includes)
        //            query = query.Include(include);
        //    return await query.SingleOrDefaultAsync(criteria);
        //}

        //public async Task<IEnumerable<Product>> GetAllAsync(string[] includes, bool withNoTracking = true)
        //{
        //    IQueryable<Product> query = _context.Set<Product>();
        //    if (withNoTracking)
        //        query = query.AsNoTracking();
        //    query = query.Where(x => !x.IsDeleted);

        //    foreach (var include in includes)
        //        query = query.Include(include);
        //    query = query.OrderByDescending(x => x.Name);
        //    return await query.ToListAsync();
        //}
        //public async Task<IEnumerable<Product>> GetAllAsync(bool withNoTracking = true)
        //{
        //    IQueryable<Product> query = _context.Set<Product>();
        //    if (withNoTracking)
        //        query = query.AsNoTracking();
        //    query = query.Where(x => !x.IsDeleted);
        //    query = query.OrderByDescending(x => x.Name);
        //    return await query.ToListAsync();
        //}



        //public async Task<Product> GetByIdAsync(Guid id, string[] includes)
        //{
        //    IQueryable<Product> query = _context.Set<Product>();
        //    if (includes != null)
        //        foreach (var include in includes)
        //            query = query.Include(include);
        //    return await query.FirstOrDefaultAsync(x => x.Id == id);
        //}


    }
}