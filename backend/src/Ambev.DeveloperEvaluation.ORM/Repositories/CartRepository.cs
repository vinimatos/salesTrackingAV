using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DefaultContext _context;

        public CartRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Carts> GetCartsById(Guid Id)
        {
            return await _context.Carts.Include(x=>x.Customer).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Carts>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Carts.ToListAsync(cancellationToken);
        }

        public async Task<Carts> CreateAsync(Carts carts, CancellationToken cancellationToken = default)
        {
            await _context.Carts.AddAsync(carts, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return carts;
        }

        public async Task<Carts> Update(Carts carts, CancellationToken cancellationToken = default)
        {
            _context.Carts.Update(carts);
            await _context.SaveChangesAsync(cancellationToken);
            return carts;
        }

    }
}
