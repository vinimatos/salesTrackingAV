﻿using Ambev.DeveloperEvaluation.Application.Products;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateProductRequest
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string? Image { get; set; }
        public RatingDTO Ratings { get; set; }
    }
}
