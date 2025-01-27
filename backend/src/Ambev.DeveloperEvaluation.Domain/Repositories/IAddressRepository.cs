using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default);
    }
}
