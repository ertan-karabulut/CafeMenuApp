using AutoMapper;
using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Application.Interface.Persistence.UoW;
using CafeMenuApp.Domain.Entities;
using CafeMenuApp.Infrastructure.Validator;

namespace CafeMenuApp.Infrastructure.Service;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryValidator _validator;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork, ICategoryValidator validator)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    public async Task<CreateCategoryResponseDto> CreateAsync(CreateCategoryRequestDto request, CancellationToken cancellationToken = default)
    {
        var category = request.CreteCategory();
        await _categoryRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CreateCategoryResponseDto>(category);
    }
    public async Task UpdateAsync(DetailCategoryDto category, CancellationToken cancellationToken = default)
    {
        var updateCategory = await _categoryRepository.GetByIdAsync(category.Id, cancellationToken) ?? throw new Exception("Kategori bulunamadı.");
        updateCategory.ParentCategoryId = category.ParentCategoryId;
        updateCategory.Name = category.Name;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<ListCategoryResponseDto>> ListAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _categoryRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<ListCategoryResponseDto>>(categories);
    }
    public async Task<DetailCategoryDto> GetDetailByIdAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Kategori bulunamadı.");
        return _mapper.Map<DetailCategoryDto>(category);
    }
    public async Task DeleteAsync(Guid id,CancellationToken cancellationToken = default)
    {
        await _validator.ValidateCategoryDeleteAsync(id, cancellationToken);
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Kategori bulunamadı.");
        category.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<RaporCategoryResponseDto>> ProductCountAsync(CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.ListWithProcutAsync(cancellationToken);
        return category.Select(x=> new RaporCategoryResponseDto
        {
            CategotyName = x.Name,
            ProductCount = x.Products.Count
        }).ToList();
    }
}
