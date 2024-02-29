using ProductMicroservice.ProductAggregate.Input;

namespace ProductMicroservice.ProductAggregate
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category? Category { get; private set; }
        public bool IsDeleted { get; private set; }
        //public Product()
        //{
            
        //}
        //public Product(ProductInput product)
        //{
        //    Name = product.Name;
        //    Description = product.Description;
        //    Price = product.Price;
        //    CategoryId = product.CategoryId;
        //}

        //public async Task SoftDelete()
        //{
        //    IsDeleted = true;
        //}

        //public async Task UpdateProduct(ProductInput input)
        //{
        //    Name = input.Name;
        //    Description = input.Description;
        //    Price = input.Price;
        //    CategoryId = input.CategoryId;
        //}
    }
}
