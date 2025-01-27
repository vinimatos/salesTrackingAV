using Ambev.DeveloperEvaluation.Application.Order;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Order.CreateOrder
{
    public class UpdateOrderCommand : IRequest<UpdateOrderCommandResult>
    {
        public Guid Id { get; set; }
        public bool IsCancelled { get; set; }
    }
}
