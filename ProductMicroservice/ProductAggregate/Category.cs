using ProductMicroservice.ProductAggregate.Input;

namespace ProductMicroservice.ProductAggregate
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }
        //public Category()
        //{
            
        //}
        //public Category(CategoryInput category)
        //{
        //    Name = category.Name;
        //    Description = category.Description;
        //}
        //public async Task SoftDelete()
        //{
        //    IsDeleted = true;
        //}

        //public async Task UpdateCategory(ProductInput input)
        //{
        //    Name = input.Name;
        //    Description = input.Description;
        //}
    }
}
