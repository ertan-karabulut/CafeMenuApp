namespace CafeMenuApp.Application.DTO.Property;
public static class RequestDtoExtension
{
    public static Domain.Entities.Property CreteProperty(this CreatePropertyRequestDto dto)
    {
        return new Domain.Entities.Property
        {
            Key = dto.Key,
            Value = dto.Value
        };
    }
}
