namespace CafeMenuApp.Application.Interface.Persistence.UoW;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    Task RollbackAsync();
    Task CommitTransactionAsync(CancellationToken cancellation = default);
    Task RollbackTransactionAsync(CancellationToken cancellation = default);
}
