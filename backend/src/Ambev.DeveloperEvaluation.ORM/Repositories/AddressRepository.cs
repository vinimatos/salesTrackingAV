using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DefaultContext _context;

        public AddressRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default)
        {
            await _context.Address.AddAsync(address, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return address;
        }
    }
}
