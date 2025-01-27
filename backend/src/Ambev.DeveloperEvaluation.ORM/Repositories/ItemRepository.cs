using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DefaultContext _context;

        public ItemRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Items> GetByIdAsync(Guid Id)
        {
            return await _context.Items.Include(c=>c.OrderItems)
                .Include(c=>c.OrderItems.Cart).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Items> CreateAsync(Items items, CancellationToken cancellationToken = default)
        {
            await _context.Items.AddAsync(items, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return items;
        }

        public async Task<IEnumerable<Items>> ReportAsync(
        string? customer,
        bool? isCancelled,
        DateTime? dateSale,
        CancellationToken cancellationToken = default)
        {
            var query = _context.Items
                .Include(x => x.OrderItems)
                .Include(x => x.OrderItems.Cart)
                .Include(x => x.Product)
                .Include(x => x.OrderItems.Cart.Customer)
                .AsQueryable();


            if (!string.IsNullOrEmpty(customer))
            {
                query = query.Where(x => x.OrderItems.Cart.Customer.Name.Contains(customer));
            }

            if (isCancelled.HasValue)
            {
                query = query.Where(x => x.OrderItems.Cart.IsCancelled == isCancelled.Value);
            }

            if (dateSale.HasValue)
            {

                var dateToCompare = dateSale.Value.Date;
                query = query.Where(x => x.OrderItems.Cart.CreateDate.Date == dateToCompare);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<List<Items>> GetOrders()
        {
            return await _context.Items.Include(x => x.OrderItems)
                                        .Include(x => x.OrderItems.Cart)
                                        .Include(x => x.OrderItems.Cart.Customer)
                                        .Include(x => x.OrderItems.Cart.Customer.Address)
                                        .Include(x => x.Product)
                                        .Where(x => x.OrderItems.Cart.IsCancelled == false)
                                        .OrderByDescending(x => x.OrderItems.Cart.CreateDate)
                                        .ToListAsync();
        }

    }
}
