using CafeMenuApp.Application.DTO.Product;
using CafeMenuApp.Application.Interface.Persistence.Repository;

namespace CafeMenuApp.Infrastructure.Validator;
public interface IProductValidator
{
    Task ValidateProductCreateAsync(CreateProductRequestDto product, CancellationToken cancellationToken = default);
}
public class ProductValidator : IProductValidator
{
    private readonly ICategoryRepository _categoryRepository;
    public ProductValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task ValidateProductCreateAsync(CreateProductRequestDto product, CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdWithSubCategoryAsync(product.CategoryId, cancellationToken)
            ?? throw new Exception("Kategori bulunamadı.");
        if (category.IsDeleted)
            throw new Exception("Kategori bulunamadı.");
    }
}
