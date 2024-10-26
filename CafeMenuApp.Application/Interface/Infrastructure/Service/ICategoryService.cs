using CafeMenuApp.Application.DTO.Category;

namespace CafeMenuApp.Application.Interface.Infrastructure.Service;

public interface ICategoryService
{
    Task<CreateCategoryResponseDto> CreateAsync(CreateCategoryRequestDto request, CancellationToken cancellationToken = default);
    Task UpdateAsync(DetailCategoryDto category, CancellationToken cancellationToken = default);
    Task<List<ListCategoryResponseDto>> ListAsync(CancellationToken cancellationToken = default);
    Task<DetailCategoryDto> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<RaporCategoryResponseDto>> ProductCountAsync(CancellationToken cancellationToken = default);
}
