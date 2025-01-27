using Ambev.DeveloperEvaluation.Application.Order.CreateOrder;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResult>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public RatingDTO Ratings { get; set; }
    }
}
