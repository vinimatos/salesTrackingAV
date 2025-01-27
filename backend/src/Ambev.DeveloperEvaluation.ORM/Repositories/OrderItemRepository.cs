using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DefaultContext _context;

        public OrderItemRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<OrderItems> GetOrderById(Guid Id)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<OrderItems> CreateAsync(OrderItems ordemItem, CancellationToken cancellationToken = default)
        {
            await _context.OrderItems.AddAsync(ordemItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ordemItem;
        }
    }
}
