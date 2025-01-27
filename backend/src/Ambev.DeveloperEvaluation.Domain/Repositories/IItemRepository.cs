using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Items> CreateAsync(Items item, CancellationToken cancellationToken = default);
        Task<IEnumerable<Items>> ReportAsync(string? customer, bool? isCancelled, DateTime? dateSale, CancellationToken cancellationToken = default);
        Task<List<Items>> GetOrders();
        Task<Items> GetByIdAsync(Guid Id);
    }
}
