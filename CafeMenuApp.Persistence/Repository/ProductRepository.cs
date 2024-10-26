using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Domain.Entities;
using CafeMenuApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CafeMenuApp.Persistence.Repository;
internal class ProductRepository : Repository<Product, CafeMenuDbContext>, IProductRepository
{
    public ProductRepository(CafeMenuDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<Product>> ListAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.Include(x=>x.Category).Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<List<Product>> CustomerListAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.Include(x => x.Category).Include(x=>x.Properties).Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.Include(x=>x.Category).Include(x=>x.Properties).Include(x=>x.Properties).Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}
