﻿namespace ProductMicroservice.ProductAggregate.Input
{
    public class ProductInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
