using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Application.Interface.Persistence.Repository;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    Task<List<User>> ListAsync(CancellationToken cancellationToken = default);
}
