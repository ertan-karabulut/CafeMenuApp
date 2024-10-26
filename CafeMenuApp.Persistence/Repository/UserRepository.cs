using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Domain.Entities;
using CafeMenuApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CafeMenuApp.Persistence.Repository;
internal class UserRepository : Repository<User, CafeMenuDbContext>, IUserRepository
{
    public UserRepository(CafeMenuDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.FirstOrDefaultAsync(x => x.UserName == userName);
    }
    public async Task<List<User>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _entitiySet.ToListAsync(cancellationToken);
    }
}
