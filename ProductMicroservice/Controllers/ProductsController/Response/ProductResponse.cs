namespace ProductMicroservice.Controllers.ProductsController.Response
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
