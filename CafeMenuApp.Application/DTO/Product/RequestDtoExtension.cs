namespace CafeMenuApp.Application.DTO.Product;

public static class RequestDtoExtension
{
    public static Domain.Entities.Product CreteProduct(this CreateProductRequestDto dto)
    {
        return new Domain.Entities.Product
        {
            Name = dto.Name,
            ImagePath = dto.ImagePath,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
        };
    }
}
