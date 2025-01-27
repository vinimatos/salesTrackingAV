using Ambev.DeveloperEvaluation.Application.Order;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResult>
    {
        public Guid CustomerId { get; set; }
        public List<OrdemItemDTO> OrderItems { get; set; }
    }
}
