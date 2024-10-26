using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Application.Interface.Persistence.Repository;
public interface IPropertyRepository : IRepository<Property>
{
    Task<List<Property>> ListAsync(CancellationToken cancellationToken = default);
    Task<Property?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
