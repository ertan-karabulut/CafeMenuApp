using CafeMenuApp.Domain.Entities;
using System.Linq.Expressions;

namespace CafeMenuApp.Application.Interface.Persistence.Repository;
public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> ListAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default);
    Task<List<Product>> CustomerListAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
