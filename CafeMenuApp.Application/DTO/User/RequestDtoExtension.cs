namespace CafeMenuApp.Application.DTO.User;
public static class RequestDtoExtension
{
    public static Domain.Entities.User CreteUser(this CreateUserRequestDto dto)
    {
        return new Domain.Entities.User
        {
            Name = dto.Name,
            SurName = dto.SurName,
            UserName = dto.UserName,
        };
    }
}
