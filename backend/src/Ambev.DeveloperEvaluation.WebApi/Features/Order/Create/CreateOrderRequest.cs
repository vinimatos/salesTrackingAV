using Ambev.DeveloperEvaluation.Application.Order;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Order.Create
{
    public class CreateOrderRequest
    {
        public Guid CustomerId { get; set; }
        public List<OrdemItemDTO> OrderItems { get; set; }
    }
}
