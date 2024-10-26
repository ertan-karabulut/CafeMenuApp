using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Application.DTO.Product;

namespace CafeMenuApp.Application.Interface.Infrastructure.Service;

public interface IProductService
{
    Task<CreateProductResponseDto> CreateAsync(CreateProductRequestDto request, CancellationToken cancellationToken = default);
    Task<List<ListProductResponseDto>> ListAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(DetailProductDto product, CancellationToken cancellationToken = default);
    Task<DetailProductDto> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<ListProductResponseDto>> CustomerListAsync(CancellationToken cancellationToken = default);
}
