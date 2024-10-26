using AutoMapper;
using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Application.DTO.Product;
using CafeMenuApp.Application.DTO.Property;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Application.Interface.Persistence.UoW;

namespace CafeMenuApp.Infrastructure.Service;
public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public PropertyService(IPropertyRepository propertyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _propertyRepository = propertyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreatePropertyResponseDto> CreateAsync(CreatePropertyRequestDto request, CancellationToken cancellationToken = default)
    {
        var property = request.CreteProperty();
        await _propertyRepository.AddAsync(property, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CreatePropertyResponseDto>(property);
    }
    public async Task UpdateAsync(DetailPropertyDto property, CancellationToken cancellationToken = default)
    {
        var updateProperty = await _propertyRepository.GetByIdAsync(property.Id, cancellationToken) ?? throw new Exception("Özellik bulunamadı.");
        updateProperty.Key = property.Key;
        updateProperty.Value = property.Value;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<ListPropertyResponseDto>> ListAsync(CancellationToken cancellationToken = default)
    {
        var property = await _propertyRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<ListPropertyResponseDto>>(property);
    }
    public async Task<DetailPropertyDto> GetDetailByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var property = await _propertyRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Özellik bulunamadı.");
        return _mapper.Map<DetailPropertyDto>(property);
    }
    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var property = await _propertyRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Özellik bulunamadı.");
        _propertyRepository.Remove(property);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
