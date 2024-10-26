using CafeMenuApp.Application.Interface.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace CafeMenuApp.Persistence.Repository;
public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
{
    protected readonly DbSet<TEntity> _entitiySet;

    public Repository(TContext dbContext)
    {
        _entitiySet = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellation)
    {
        await _entitiySet.AddAsync(entity, cancellation);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation)
    {
        await _entitiySet.AddRangeAsync(entities, cancellation);
    }

    public void Update(TEntity entity)
    {
        _entitiySet.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _entitiySet.UpdateRange(entities);
    }

    public virtual void Remove(TEntity entity)
    {
        _entitiySet.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        _entitiySet.RemoveRange(entities);
    }
}
