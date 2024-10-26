using CafeMenuApp.Application.Interface.Persistence.UoW;
using CafeMenuApp.Persistence.Context;

namespace CafeMenuApp.Persistence.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly CafeMenuDbContext _dbContext;


    public UnitOfWork(CafeMenuDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellation = default)
    {
        return await _dbContext.SaveChangesAsync(cancellation);
    }

    public async Task RollbackAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
        await _dbContext.DisposeAsync();
    }
    public async Task CommitTransactionAsync(CancellationToken cancellation = default)
    {
        try
        {
            await _dbContext.Database.CommitTransactionAsync(cancellation);
        }
        catch (Exception)
        {
            await RollbackTransactionAsync(cancellation);
            throw;
        }
        finally
        {
            await _dbContext.DisposeAsync();
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellation = default)
    {
        try
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellation);
        }
        finally
        {
            await _dbContext.DisposeAsync();
        }
    }
}
