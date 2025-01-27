using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> CreateAsync(Rating product, CancellationToken cancellationToken = default);
        Task<Rating?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Rating> UpdateAsync(Rating rating, CancellationToken cancellationToken = default);
    }
}
