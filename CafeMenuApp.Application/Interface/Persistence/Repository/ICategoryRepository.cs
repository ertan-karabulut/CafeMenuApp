using CafeMenuApp.Domain.Entities;
using System.Linq.Expressions;

namespace CafeMenuApp.Application.Interface.Persistence.Repository;
public interface ICategoryRepository : IRepository<Category>
{
    Task<List<Category>> ListAsync(CancellationToken cancellationToken = default);
    Task<List<Category>> ListWithProcutAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Category?> GetByIdWithSubCategoryAsync(Guid id, CancellationToken cancellationToken = default);
}
