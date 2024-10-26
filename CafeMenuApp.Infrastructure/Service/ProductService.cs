using AutoMapper;
using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Application.DTO.Product;
using CafeMenuApp.Application.DTO.Property;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Application.Interface.Persistence.UoW;
using CafeMenuApp.Domain.Entities;
using CafeMenuApp.Infrastructure.Validator;

namespace CafeMenuApp.Infrastructure.Service;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductValidator _validator;
    public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork, IProductValidator validator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    public async Task<CreateProductResponseDto> CreateAsync(CreateProductRequestDto request, CancellationToken cancellationToken = default)
    {
        await _validator.ValidateProductCreateAsync(request, cancellationToken);
        var product = request.CreteProduct();
        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CreateProductResponseDto>(product);
    }
    public async Task<List<ListProductResponseDto>> ListAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _productRepository.ListAsync(x => true, cancellationToken);
        return _mapper.Map<List<ListProductResponseDto>>(categories);
    }
    public async Task<DetailProductDto> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Ürün bulunamadı.");
        return _mapper.Map<DetailProductDto>(product);
    }
    public async Task UpdateAsync(DetailProductDto product, CancellationToken cancellationToken = default)
    {
        var updateProduct = await _productRepository.GetByIdAsync(product.Id, cancellationToken) ?? throw new Exception("Ürün bulunamadı.");
        updateProduct.Name = product.Name;
        updateProduct.Price = product.Price;
        updateProduct.ImagePath = product.ImagePath;
        updateProduct.CategoryId = product.CategoryId;
        AddProductProperty(updateProduct, product.Properties.Where(x=>x.IsSelected == true).ToList());
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Ürün bulunamadı.");
        product.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ListProductResponseDto>> CustomerListAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _productRepository.CustomerListAsync(x => x.IsDeleted==false, cancellationToken);
        return _mapper.Map<List<ListProductResponseDto>>(categories);
    }

    private void AddProductProperty(Product product, List<DetailPropertyDto> propertyDto)
    {
        var newPropertyIds = propertyDto.Select(x => x.Id).ToList();
        var removePropertyList = product.Properties.Where(x=> !newPropertyIds.Contains(x.Id)).ToList();
        removePropertyList.ForEach(item=>  product.Properties.Remove(item));
        var addList = propertyDto.Where(x => !product.Properties.Select(y => y.Id).ToList().Contains(x.Id)).ToList();
        var properties = _mapper.Map<List<Property>>(addList);
        properties.ForEach(item=> product.Properties.Add(item));
    }
}
