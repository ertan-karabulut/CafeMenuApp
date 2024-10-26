using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Domain.Entities;
using CafeMenuApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CafeMenuApp.Persistence.Repository;
internal class PropertyRepository : Repository<Property, CafeMenuDbContext>, IPropertyRepository
{
    public PropertyRepository(CafeMenuDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<Property>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _entitiySet.ToListAsync(cancellationToken);
    }
    public async Task<Property?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.FirstOrDefaultAsync(x=>x.Id == id,cancellationToken);
    }
}
