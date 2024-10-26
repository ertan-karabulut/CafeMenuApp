using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Application.DTO.Category;

public static class RequestDtoExtension
{
    public static Domain.Entities.Category CreteCategory(this CreateCategoryRequestDto dto)
    {
        return new Domain.Entities.Category
        {
            Name = dto.Name,
            ParentCategoryId = dto.ParentCategoryId,
        };
    }
}
