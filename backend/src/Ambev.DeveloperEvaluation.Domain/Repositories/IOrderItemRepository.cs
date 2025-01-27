using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        Task<OrderItems> CreateAsync(OrderItems ordemItem, CancellationToken cancellationToken = default);
        Task<OrderItems> GetOrderById(Guid Id);
    }
}
