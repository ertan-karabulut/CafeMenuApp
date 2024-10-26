using CafeMenuApp.Application.DTO.Property;

namespace CafeMenuApp.Application.Interface.Infrastructure.Service;

public interface IPropertyService
{
    Task<CreatePropertyResponseDto> CreateAsync(CreatePropertyRequestDto request, CancellationToken cancellationToken = default);
    Task UpdateAsync(DetailPropertyDto property, CancellationToken cancellationToken = default);
    Task<List<ListPropertyResponseDto>> ListAsync(CancellationToken cancellationToken = default);
    Task<DetailPropertyDto> GetDetailByIdAsync(int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
