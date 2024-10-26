using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Domain.Entities;
using CafeMenuApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CafeMenuApp.Persistence.Repository;
internal class CategoryRepository : Repository<Category, CafeMenuDbContext>, ICategoryRepository
{
    public CategoryRepository(CafeMenuDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Category>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _entitiySet.ToListAsync(cancellationToken);
    }

    public async Task<List<Category>> ListWithProcutAsync(CancellationToken cancellationToken = default)
    {
        return await _entitiySet.Include(x=>x.Products).ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.Include(x=>x.ParentCategory).Where(x=>x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<Category?> GetByIdWithSubCategoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entitiySet.AsNoTracking().Where(x => x.Id == id).Include(x=>x.SubCategories).FirstOrDefaultAsync(cancellationToken);
    }

}
