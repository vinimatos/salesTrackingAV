using Ambev.DeveloperEvaluation.Application.Order;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Order.Create
{
    public class UpdateOrderRequest
    {
        public Guid CustomerId { get; set; }
        public bool IsCancelled { get; set; }
    }
}
