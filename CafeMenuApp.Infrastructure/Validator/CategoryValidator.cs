using CafeMenuApp.Application.Interface.Persistence.Repository;

namespace CafeMenuApp.Infrastructure.Validator;
public interface ICategoryValidator
{
    Task ValidateCategoryDeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
public class CategoryValidator : ICategoryValidator
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task ValidateCategoryDeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdWithSubCategoryAsync(id, cancellationToken)
            ?? throw new Exception("Kategori bulunamadı.");
        if (category.IsDeleted)
            throw new Exception("Kategori silinmiş.");
        if(category.SubCategories.Any(x=>x.IsDeleted == false))
            throw new Exception("Alt kategorileri mevcut");
    }
}
