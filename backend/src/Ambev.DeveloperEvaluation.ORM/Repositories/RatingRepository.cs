using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of RatingRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public RatingRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Rating> CreateAsync(Rating rating, CancellationToken cancellationToken = default)
    {
        await _context.Ratings.AddAsync(rating, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return rating;
    }

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Rating?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Ratings.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<Rating> UpdateAsync(Rating rating, CancellationToken cancellationToken = default)
    {
        _context.Ratings.Update(rating);
        await _context.SaveChangesAsync(cancellationToken);
        return rating;
    }
}
