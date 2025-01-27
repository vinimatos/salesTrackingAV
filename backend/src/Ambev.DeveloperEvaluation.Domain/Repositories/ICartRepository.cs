using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Carts> CreateAsync(Carts cart, CancellationToken cancellationToken = default);
        Task<List<Carts>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Carts> GetCartsById(Guid Id);
        Task<Carts> Update(Carts carts, CancellationToken cancellationToken = default);
    }
}
