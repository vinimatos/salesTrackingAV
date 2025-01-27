using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customers> CreateAsync(Customers customer, CancellationToken cancellationToken = default);
        Task<List<Customers>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customers?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Customers> UpdateAsync(Customers customer, CancellationToken cancellationToken = default);
    }
}
